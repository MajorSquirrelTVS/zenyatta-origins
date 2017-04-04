using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOrb : MonoBehaviour {

    public float expiryTime = 2f;
	public int damage = 10;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, expiryTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
