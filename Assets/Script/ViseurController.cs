using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViseurController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMouse.z = 0;
        transform.position = posMouse;

        GameObject zenyatta = GameObject.FindGameObjectWithTag("Player");
        ZenattyaController playerController =  zenyatta.GetComponent<ZenattyaController>();

        if (transform.position.x - zenyatta.transform.position.x < 0 && playerController.facingRight)
            playerController.Flip();
        else if (transform.position.x - zenyatta.transform.position.x > 0 && !playerController.facingRight)
            playerController.Flip();

    }
}
