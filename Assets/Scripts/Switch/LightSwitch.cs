using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public GameObject connect_object;
    public Sprite turn_on_sprite;
    bool is_on;
    Sprite turn_off_sprite;

    // Use this for initialization
    void Start()
    {
        is_on = false;
        turn_off_sprite = transform.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (connect_object.GetComponent<LampionSwitch>().getIsOpen() == true)
        {
            is_on = true;
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = turn_on_sprite;
        }
        else
        {
            is_on = false;
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = turn_off_sprite;
        }
    }

    public bool isOn()
    {
        return is_on;
    }
}
