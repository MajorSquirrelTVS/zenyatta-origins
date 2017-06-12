using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combinaison;

public class DoorLampionSwitch : MonoBehaviour {

    public GameObject lampionSwitchFirst;
    public GameObject lampionSwitchSecond;
    public GameObject lampionSwitchThird;
    public GameObject lampionSwitchFourth;
    public GameObject lampionSwitchFifth;
    public Door position;

    public Sprite openedSprite;
    Sprite closedSprite;
    GameObject[] LampionSwitchs;
    // Use this for initialization
    void Start()
    {
        closedSprite = transform.GetComponent<SpriteRenderer>().sprite;
        LampionSwitchs = new GameObject[5];
        LampionSwitchs[0] = lampionSwitchFirst;
        LampionSwitchs[1] = lampionSwitchSecond;
        LampionSwitchs[2] = lampionSwitchThird;
        LampionSwitchs[3] = lampionSwitchFourth;
        LampionSwitchs[4] = lampionSwitchFifth;

    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            LampionSwitchDoor test = LampionSwitchs[i].GetComponent<LampionSwitchDoor>();
            if (test.getIsOpen(position))
                count++;
        }
        if (count == 5)
            open();
        else
            close();
    }

    void open()
    {
        transform.GetComponent<SpriteRenderer>().sprite = openedSprite;
        transform.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void close()
    {
        transform.GetComponent<SpriteRenderer>().sprite = closedSprite;
        transform.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
