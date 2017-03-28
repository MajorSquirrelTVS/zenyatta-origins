using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenattyaController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    bool facingRight = true;
    bool grounded = true;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        /** JUMP **/

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        /** JUMP **/


        /** MOVEMENT **/

        float move = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        /** MOVEMENT **/
	}

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
