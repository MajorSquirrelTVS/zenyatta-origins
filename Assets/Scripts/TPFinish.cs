using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPFinish : MonoBehaviour {

    GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            gameController.setRestart(true);
            gameController.setFinish(true);
        }
    }
}
