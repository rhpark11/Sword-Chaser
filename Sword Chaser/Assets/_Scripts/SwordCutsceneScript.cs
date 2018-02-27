using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCutsceneScript : MonoBehaviour {

    public PlayerController player;

    CountDownTimer timerScript;
    CircleCollider2D c_collider;
    Vector3 target;
    int speed = 3;

    //sword time y axis
    private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
        timerScript = this.gameObject.transform.GetChild(0).gameObject.GetComponent<CountDownTimer>();
        c_collider = GetComponent<CircleCollider2D>();
        c_collider.enabled = false;
		target = new Vector3(-5f, -0.5f, 0f);

    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;

        if (transform.position.x != -5f && transform.position.y != -0.5f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else if (transform.GetChild(0).transform.gameObject.activeInHierarchy == true && timerScript.start == true)
        {
            player.startGame = true;
            transform.position = target;
            c_collider.enabled = true;
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }
        else if(transform.GetChild(0).transform.gameObject.activeInHierarchy == false && timerScript.start == false)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            //transform.position = new Vector3(0, Mathf.Sin(elapsedTime),0); //elaspedTime += Time.delta;
        }

    }
}
