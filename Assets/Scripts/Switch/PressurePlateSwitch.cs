using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSwitch : MonoBehaviour {


    public GameObject connect_object;
    public bool is_on;
	// Use this for initialization
	void Start () {
        is_on = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(is_on);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == connect_object)
        {
            is_on = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject == connect_object)
        {
            is_on = false;
        }
    }
}
