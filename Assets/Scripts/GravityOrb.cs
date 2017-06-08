using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrb : MonoBehaviour {

    public GameObject GravityEffect;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enableGravity() {
        GameObject IGravityEffect = Instantiate(GravityEffect, transform.position, Quaternion.identity);
        Destroy(IGravityEffect, 0.05f);
        Destroy(gameObject);
    }
}
