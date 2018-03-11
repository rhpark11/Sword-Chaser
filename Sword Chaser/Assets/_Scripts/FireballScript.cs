using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {
    public float velocity = 4f;
    public float frequency = .9f;
    public GameOver gameover;
    private float x,y;
    //private float elapsedTime;

    private float originalY, originalX;
    // Use this for initialization
    void Start () {
        x = 0f;
        y = 0f;
        //elapsedTime = 0f;
        gameover = GameObject.Find("GameOverController").GetComponent<GameOver>();
        originalY = this.transform.position.y+.5f;
        originalX = this.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        //x = elapsedTime;
        //y = Mathf.Sin(x);
        elapsedTime += Time.deltaTime;
        transform.position += new Vector3(-(velocity + elapsedTime), originalY + (Mathf.Sin(Time.deltaTime) ), 0);// * Time.deltaTime;
        */
        Vector3 ballPos = this.transform.position;
        y = Mathf.Sin(2 * Mathf.PI * Time.time) * frequency;
        x -= Time.deltaTime * velocity;
        ballPos.y = originalY + y;
        ballPos.x = originalX + x;
        this.transform.position = ballPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameover.gameOver();
            Destroy(collision.gameObject, 0.01f);
        }
    }
}
