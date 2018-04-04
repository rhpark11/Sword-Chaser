using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCutsceneScript : MonoBehaviour {

    public PlayerController player;

    CountDownTimer timerScript;
    CircleCollider2D c_collider;
    Vector3 target;
    int speed = 4;

    //control the hover during timer intro
    private bool inTimer = false;
    private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
        timerScript = this.gameObject.transform.GetChild(0).gameObject.GetComponent<CountDownTimer>();
        c_collider = GetComponent<CircleCollider2D>();
        c_collider.enabled = false;
		target = new Vector3(2f, 0.5f, 0f);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.anyKeyDown)
        {
            transform.position = target;
            
            transform.GetChild(0).transform.gameObject.SetActive(true);
            timerScript.skip();
            inTimer = false;
        }
        if (transform.position.x != 2f && transform.position.y != 0.5f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else if (transform.GetChild(0).transform.gameObject.activeInHierarchy == true && timerScript.start == true)
        {
            player.startGame = true;
            //transform.position = target;
            c_collider.enabled = true;
            transform.GetChild(0).transform.gameObject.SetActive(false);
            inTimer = false;
        }
        else if(transform.GetChild(0).transform.gameObject.activeInHierarchy == false && timerScript.start == false)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            inTimer = true;
        }
        if(inTimer)
        {
            float x = elapsedTime * 3;
            elapsedTime += Time.deltaTime;
            transform.Translate(0,-Mathf.Sin(x) * Time.deltaTime,0);
        }
    }
}
