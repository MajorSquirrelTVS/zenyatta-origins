using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combinaison;

public class LampionSwitchDoor : MonoBehaviour {

    public Sprite FirstSprite;
    public Sprite SecondSprite;
    public Sprite ThirdSprite;
    public Sprite FourthSprite;
    public Sprite FifthSprite;
    public Sprite GoodColorFirst;
    public Sprite GoodColorSecond;
    public Sprite GoodColorThird;
    public Sprite GoodColorFourth;

    private Sprite[] SpriteTab;

    private bool[] isOpen;
    private Sprite[] goodColor;
    private int index;

    // Use this for initialization
    void Start()
    {
        SpriteTab = new Sprite[5];
        SpriteTab[0] = FirstSprite;
        SpriteTab[1] = SecondSprite;
        SpriteTab[2] = ThirdSprite;
        SpriteTab[3] = FourthSprite;
        SpriteTab[4] = FifthSprite;

        index = 0;
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteTab[index];

        isOpen = new bool[4];
        isOpen[0] = false;
        isOpen[1] = false;
        isOpen[2] = false;
        isOpen[3] = false;

        goodColor = new Sprite[4];
        goodColor[0] = GoodColorFirst;
        goodColor[1] = GoodColorSecond;
        goodColor[2] = GoodColorThird;
        goodColor[3] = GoodColorFourth;
        
    }

    // Update is called once per frame
    void Update()
    {


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
        for (int i = 0; i < 4; i++)
        {
            if (goodColor[i] == SpriteTab[index])
                isOpen[i] = true;
            else
                isOpen[i] = false;
        }
    }

    public bool getIsOpen(Door whichOne)
    {
        switch (whichOne) { 
            case Door.FIRST: return isOpen[0];
            case Door.SECOND: return isOpen[1];
            case Door.THIRD: return isOpen[2];
            case Door.FINAL: return isOpen[3];
        }

        return false;
    }
}
