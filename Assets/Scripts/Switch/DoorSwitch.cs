using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {


    public GameObject triggerSwitch;
    public Sprite openedSprite;
    Sprite closedSprite;
    TargetSwitch trig;
    // Use this for initialization
	void Start () {
        closedSprite = transform.GetComponent<SpriteRenderer>().sprite;
        trig = triggerSwitch.GetComponent<TargetSwitch>();
	}
	
	// Update is called once per frame
	void Update () {
		if (trig.getIsOpen())
        {
            transform.GetComponent<SpriteRenderer>().sprite = openedSprite;
            transform.GetComponent<BoxCollider2D>().enabled = false;
        } else
        {
            transform.GetComponent<SpriteRenderer>().sprite = closedSprite;
            transform.GetComponent<BoxCollider2D>().enabled = true;
        }
	}
}
