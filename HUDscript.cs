using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour {

    float playerScore = 0;
	
	// Update is called once per frame
	void Update () {
        playerScore += Time.deltaTime;
	}

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (playerScore * 100));
    }
}
