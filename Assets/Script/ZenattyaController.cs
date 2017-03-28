using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenattyaController : MonoBehaviour {

    public float MaxSpeed = 10.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");

        Rigidbody2D rigidbody= GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(move * MaxSpeed * Time.deltaTime, transform.position.y);

	}
}
