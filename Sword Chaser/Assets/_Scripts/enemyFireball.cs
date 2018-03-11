using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireball : MonoBehaviour {

    public GameOver gameover;
    public float fireTime = 1.5f;
    public float maxFireTime = 3f;

    public GameObject fBall;
    // Use this for initialization
    void Start ()
    {
        //fBall = GameObject.Find("Fireball");
        gameover = GameObject.Find("GameOverController").GetComponent<GameOver>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //add random times
        if (fireTime <= 0)
        {
            fire();
            fireTime = maxFireTime;
        }
        fireTime -= Time.deltaTime;
	}

    void fire()
    {
        GameObject fBallClone = (GameObject)Instantiate(fBall, transform.position, Quaternion.identity);
    }
}
