using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPFinish_2 : MonoBehaviour {

    GameController gameController;
    public Sprite turnOnSprite;
    bool turn_on;
    GameObject[] plates;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        turn_on = false;
        plates = GameObject.FindGameObjectsWithTag("Lampion");

    }

    // Update is called once per frame
    void Update()
    {

        if (plates[0].GetComponent<LampionSwitch>().getIsOpen() == true
            && plates[1].GetComponent<LampionSwitch>().getIsOpen() == true
            && plates[2].GetComponent<LampionSwitch>().getIsOpen() == true)
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
            gameController.goLevel2();
        }
    }
}
