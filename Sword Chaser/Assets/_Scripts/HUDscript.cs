using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour {

    public PlayerController player;
    public Text ScoreText;
    public Text TimeText;

    float time = 0f;
    float seconds = 0f;
    float score = 0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.startGame == true)
        {
            time += Time.deltaTime * 100;
            if (time >= 100)
            {
                seconds += 1f;
                time = 0f;
            }
            ScoreText.text = "Score: " + score.ToString();
            TimeText.text = "Time: " + seconds.ToString();
        }

    }


    public void IncreaseScore(int amount)
    {
        score += amount;
    }


    public float getScore()
    {
        return score;
    }
    public float getTime()
    {
        return seconds;
    }
}
