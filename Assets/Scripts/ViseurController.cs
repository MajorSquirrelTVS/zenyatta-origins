using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenyatta;

public class ViseurController : MonoBehaviour {

    public float shootRate = 0f;
    private float shootRateTimeStamp = 0f;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        /** MOVING RETICULE **/
        Vector3 posMouse = Input.mousePosition;
        posMouse.z = 0;

        transform.position = posMouse;
        /** MOVING RETICULE **/

        /** LIMITATION OF RETICULE **/
        if (transform.position.x > Screen.width)
            transform.position = new Vector2(Screen.width, transform.position.y);
        if (transform.position.x <= 0)
            transform.position = new Vector2(0, transform.position.y);
        if (transform.position.y > Screen.height)
            transform.position = new Vector2(transform.position.x, Screen.height);
        if (transform.position.y <= 0)
            transform.position = new Vector2(transform.position.x, 0);
        /** LIMITATION OF RETICULE **/

        /** FACING OF PLAYER WITH RETICULE **/
        Vector3 posMouseCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject zenyatta = GameObject.FindGameObjectWithTag("Player");
        ZenattyaController playerController =  zenyatta.GetComponent<ZenattyaController>();

        if (posMouseCamera.x - zenyatta.transform.position.x < 0 && playerController.facingRight)
            playerController.Flip();
        else if (posMouseCamera.x - zenyatta.transform.position.x > 0 && !playerController.facingRight)
            playerController.Flip();
        /** FACING OF PLAYER WITH RETICULE **/

        /** INPUT SHOOTING **/
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && Time.time > shootRateTimeStamp) { //left click
            playerController.FireShot(Projectile.BASIC, posMouseCamera, 30);
            shootRateTimeStamp = Time.time + shootRate;
        }

        if (Input.GetMouseButtonDown(1)) {
            playerController.FireShot(Projectile.GRAVITY, posMouseCamera, 10);
        }
        if (Input.GetMouseButtonDown(2)) {
            playerController.FireShot(Projectile.EXPULSE, posMouseCamera, 10);
        }
        /** INPUT SHOOTING **/
    }
}
