using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
          
    }

    public void setRestart(bool value)
    {
        restart = value;
    }

    public void setFinish(bool value)
    {
        finish = value;
    }

    public void goLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void goLevel3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void goLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }
}
