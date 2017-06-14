using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp_Tuto : MonoBehaviour {

	 GameController gameController;
    public Sprite turnOnSprite;
    bool turn_on;
    GameObject[] plates;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        turn_on = false;
        plates = GameObject.FindGameObjectsWithTag("PressurePlate");

    }

    // Update is called once per frame
    void Update()
    {

        if (plates[0].GetComponent<PressurePlateSwitch>().isOn() == true
            && plates[1].GetComponent<PressurePlateSwitch>().isOn() == true)
        {
            turn_on = true;
            transform.gameObject.GetComponent<SpriteRenderer>().sprite = turnOnSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" && turn_on == true)
        {
            gameController.goLevel1();
        }
    }
}
