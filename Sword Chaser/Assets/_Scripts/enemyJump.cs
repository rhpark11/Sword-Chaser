using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyJump : MonoBehaviour {

    public float jumpForce = 500f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));//make the enemy go up and then drop back down
        }
    }
}
