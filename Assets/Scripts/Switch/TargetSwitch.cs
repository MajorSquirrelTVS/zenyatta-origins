using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwitch : MonoBehaviour {

    bool isOpen;

    // Use this for initialization
    void Start () {
        isOpen = false;
        transform.gameObject.GetComponent<Animator>().Play("FireItPause");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log("Switch");
        Debug.Log(isOpen);
        if (isOpen && other.gameObject.tag == "Orb")
        {
            isOpen = false; // close
            transform.gameObject.GetComponent<Animator>().Play("FireItPause");
            Destroy(other.gameObject);
        }
        else if (!isOpen && other.gameObject.tag == "Orb")
        {
            isOpen = true; //open
            transform.gameObject.GetComponent<Animator>().Play("FireItActivated");
            Destroy(other.gameObject);
        }
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}
