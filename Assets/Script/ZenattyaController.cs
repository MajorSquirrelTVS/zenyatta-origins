using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenattyaController : MonoBehaviour {

    public float MaxSpeed = 10.0f;
    bool facingRight = true;
    bool grounded = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

        Rigidbody2D rigidbody= GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(move * MaxSpeed, rigidbody.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
