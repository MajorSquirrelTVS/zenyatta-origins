using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenattyaController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    public bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
    public GameObject orb;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        /** JUMP state **/

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        /** JUMP state **/


        /** MOVEMENT **/

        float move = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

        /*if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
            */
        /** MOVEMENT **/
	}

    void Update()
    {
        /** JUMPING **/

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        /** JUMPING **/
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool getFacing()
    {
        return facingRight;
    }

    public void FireShot(Vector2 targetPos)
    {
        Vector2 orbSpawner = gameObject.transform.position;
        Vector2 direction;

        orbSpawner.x += (facingRight ? 1 : -1);
        direction.x = targetPos.x - orbSpawner.x;
        direction.y = targetPos.y - orbSpawner.y;

        GameObject newOrb = Instantiate(orb, orbSpawner, gameObject.transform.rotation) as GameObject;
        Rigidbody2D rb = newOrb.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * 30;
    }
}
