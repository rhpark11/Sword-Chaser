using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerOnCollision : MonoBehaviour {

    public GameOver gameover;

	// Use this for initialization
	void Start () {
        //Destroy(gameObject, 3f); destroy after a delay
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
            //call the game over script because player object has been destroyed
        }
    }
}
