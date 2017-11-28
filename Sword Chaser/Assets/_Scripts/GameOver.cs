using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Transform canvas;

	// Use this for initialization
	void Start ()
    {
        if (canvas.gameObject.activeInHierarchy == true)
            canvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if dead, gameover()
        /*
        if (Input.GetKeyDown("i"))
        {
            gameOver();
        }*/
    }

    public void gameOver()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Score()
    {

    }

    public void mainMenuButton()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
