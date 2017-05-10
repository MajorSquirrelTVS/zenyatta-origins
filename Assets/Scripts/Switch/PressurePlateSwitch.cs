using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSwitch : MonoBehaviour {


    public GameObject connect_object;
    public Sprite turn_on_sprite;
    public bool is_on;
    Sprite turn_off_sprite;

	// Use this for initialization
	void Start () {
        is_on = false;
        turn_off_sprite = transform.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(is_on);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject == connect_object)
        {
            if (col.gameObject.transform.position.y > transform.position.y)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = turn_on_sprite;
                is_on = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject == connect_object)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = turn_off_sprite;
            is_on = false;
        }
    }
    
}

