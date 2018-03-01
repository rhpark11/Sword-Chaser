using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerOnCollision : MonoBehaviour {

    public GameOver gameover;
    public GameObject game;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("GameOverController");
        gameover = game.GetComponent<GameOver>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && gameObject != null)
        {
            gameover.gameOver();
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
