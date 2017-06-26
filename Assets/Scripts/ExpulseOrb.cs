using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpulseOrb : MonoBehaviour {

    public GameObject ExpulseEffect;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enableExpulse() {
        GameObject IGravityEffect = Instantiate(ExpulseEffect, transform.position, Quaternion.identity);
        Destroy(IGravityEffect, 0.05f);
        Destroy(gameObject);
    }
}
