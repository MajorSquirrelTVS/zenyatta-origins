using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public Text restartText;
    public Text finishText;

    bool restart;
    bool finish;
    // Use this for initialization
    void Start () {
        restart = false;
        finish = false;
        restartText.text = "";
        finishText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (restart)
            restartText.text = "Press R for restart";
        else
            restartText.text = "";

        if (finish)
            finishText.text = "Finish !";
        else
            finishText.text = "";
    }

    void setRestart(bool value)
    {
        restart = value;
    }

    void setFinish(bool value)
    {
        finish = value;
    }
}
