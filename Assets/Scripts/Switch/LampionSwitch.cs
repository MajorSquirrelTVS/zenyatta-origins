using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampionSwitch : MonoBehaviour {

    public Sprite FirstSprite;
    public Sprite SecondSprite;
    public Sprite ThirdSprite;
    public Sprite FourthSprite;
    public Sprite FifthSprite;
    public Sprite GoodColor;

    private Sprite[] SpriteTab;

    private bool isOpen;
    private int index;

    // Use this for initialization
    void Start () {
        SpriteTab = new Sprite[5];
        SpriteTab[0] = FirstSprite;
        SpriteTab[1] = SecondSprite;
        SpriteTab[2] = ThirdSprite;
        SpriteTab[3] = FourthSprite;
        SpriteTab[4] = FifthSprite;
        index = 0;
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTab[index];
        isOpen = false;
    }

    // Update is called once per frame
    void Update () {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Orb")
        {
            changeColour();
            Destroy(other.gameObject);
        }
        
    }

    void changeColour()
    {
        index += 1;
        if (index == 5)
            index = 0;
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTab[index];
        if (GoodColor == SpriteTab[index])
            isOpen = true;
        else
            isOpen = false;
       
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}
