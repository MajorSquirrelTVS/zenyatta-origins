using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        transform.localPosition = new Vector3(Player.transform.position.x, transform.localPosition.y, transform.localPosition.z);
	}
}
