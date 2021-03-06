﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Transform canvas;
    public HUDscript hscript;
    public Text scoreText;

    public bool isGameOver;

	// Use this for initialization
	void Start ()
    {
        isGameOver = false;
        scoreText.text = "";
        if (canvas.gameObject.activeInHierarchy == true)
            canvas.gameObject.SetActive(false);
    }

	void Update ()
    {
    }

    public void gameOver()
    {
        isGameOver = true;
        canvas.gameObject.SetActive(true);
        setScore();
        Time.timeScale = 0;
    }

    public void setScore()
    {
        float finalscore = hscript.getScore() + hscript.getTime();
        scoreText.text = "Score: " + finalscore.ToString();
    }

    public void mainMenuButton()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
