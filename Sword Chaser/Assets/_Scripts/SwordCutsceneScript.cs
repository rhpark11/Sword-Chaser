using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCutsceneScript : MonoBehaviour {

    public PlayerController player;

    Vector3 target;
    int speed = 3;

	// Use this for initialization
	void Start () {
		target = new Vector3(-3f, -0.5f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x != -3 && transform.position.y != -0.5)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else
        {
            player.startGame = true;
            transform.position = target;
        }

    }
}
