using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour {

    public PlayerController player;

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
        }
    }


    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Time: " + seconds);
        GUI.Label(new Rect(10, 40, 100, 30), "Score: " + score);
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
