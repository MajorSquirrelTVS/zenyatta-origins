using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenyatta;

public class ZenattyaController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    public bool facingRight = true;
    bool grounded = false;
    bool stuckOnWall = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public float jumpForce = 700.0f;
    public GameObject orb;
    public GameObject gravityOrb;
    public GameObject expulseOrb;
    Rigidbody2D rigidbody;
    AudioSource orbSoundShot;

    // Use this for initialization
    void Awake()
    {
        orbSoundShot = transform.GetComponent<AudioSource>();
    }

    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
        //rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous; rigidbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        /** JUMP state **/

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        /** JUMP state **/
        // Get the velocity
        /*Vector3 horizontalMove = rigidbody.velocity;
        // Don't use the vertical velocity
        horizontalMove.y = 0;
        // Calculate the approximate distance that will be traversed
        float distance = horizontalMove.magnitude * Time.fixedDeltaTime;
        // Normalize horizontalMove since it should be used to indicate direction
        horizontalMove.Normalize();
        RaycastHit hit;

        // Check if the body's current velocity will result in a collision
        if (rigidbody.SweepTest(horizontalMove, out hit, distance))
        {
            // If so, stop the movement
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }*/

        /** MOVEMENT **/

        float move = 0.0f;

        move = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

        /** MOVEMENT **/
	}

    void Update()
    {
        /** JUMPING **/

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0.0f, jumpForce));
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

    public void FireShot(Projectile type, Vector2 targetPos, int speed)
    {
        GameObject prefabOrb = getOrb(type);
        GameObject existingOrb;

        if (type != Projectile.BASIC &&
                (existingOrb = GameObject.FindGameObjectWithTag("Gravity"))) {
            existingOrb.GetComponent<GravityOrb>().enableGravity();
        } else if (type != Projectile.BASIC &&
                (existingOrb = GameObject.FindGameObjectWithTag("Expulse"))) {
            existingOrb.GetComponent<ExpulseOrb>().enableExpulse();
        } else {
            Vector2 orbSpawner = gameObject.transform.position;
            Vector2 direction;

            orbSpawner.x += (facingRight ? 1 : -1);
            direction.x = targetPos.x - orbSpawner.x;
            direction.y = targetPos.y - orbSpawner.y;

            GameObject newOrb = Instantiate(prefabOrb, orbSpawner, gameObject.transform.rotation) as GameObject;
            Rigidbody2D rb = newOrb.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * speed;
            orbSoundShot.Play();
        }
    }

    private GameObject getOrb(Projectile type) 
    {
        switch (type) {
            case Projectile.BASIC: return orb;
            case Projectile.GRAVITY: return gravityOrb;
            case Projectile.EXPULSE: return expulseOrb;
            default: return null;
        }
    }
}
