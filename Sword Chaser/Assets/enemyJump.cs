using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyJump : MonoBehaviour {

    public float jumpForce = 10;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));//make the enemy go up to a max and then drop back down
    }
}
