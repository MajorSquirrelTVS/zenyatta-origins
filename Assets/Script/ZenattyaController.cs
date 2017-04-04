using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenattyaController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    public bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
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
        /** facing zenyatt **/
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        /** facing zenyatt **/
    }

    public bool getFacing()
    {
        return facingRight;
    }
}
