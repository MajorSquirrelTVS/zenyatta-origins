using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwitch : MonoBehaviour {

    bool isOpen;

	// Use this for initialization
	void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(transform.gameObject.name);
        Debug.Log("Switch");
        if (isOpen)
            isOpen = false; // close
        else
            isOpen = true; //open
    }
}
