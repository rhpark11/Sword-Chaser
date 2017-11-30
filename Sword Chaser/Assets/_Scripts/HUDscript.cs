using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour {

    float time = 0f;
    float seconds = 0f;
    float score = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 100;
        if (time >= 100)
        {
            seconds += 1f;
            time = 0f;
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
}
