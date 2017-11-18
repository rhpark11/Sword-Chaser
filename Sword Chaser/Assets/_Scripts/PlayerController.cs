using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    bool startGame = false; //start the motion of the player
    float start = 0;//don't start running until player moves the character

    public float jumpForce = 500f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
    void FixedUpdate()
    {
        //check to see if player has touched the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //set variable for animator to queue animation
        anim.SetBool("Ground", grounded);

        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            startGame = true;
            start = 1;
        }
        //set variable for animator; always running
        anim.SetFloat("Speed", start);// Mathf.Abs(move));

        //set variable for animator; set the vertical speed to play the jump animations from the Blend Tree
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update() {
        //set velocity of player to the right
        if (startGame) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
        }
        
        //if the player is grounded and the space is pressed then jump
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
