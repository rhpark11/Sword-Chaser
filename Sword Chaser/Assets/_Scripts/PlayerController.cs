using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject sword;

    Animator anim;
    bool isJumpRunning;
    float maxJumpTime;
    float jumpTime;
    int move;
    public bool startGame = false; //start the motion of the player
    //float start = 0;//don't start running until player moves the character

    /* use these to check if grounded to run jump or fall states
    */
    public float jumpForce = 4f;
    public bool grounded = false;
    public static bool playerIsGrounded = true;//static variable for SwordScript to reference
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public GameOver gOverScript;

    /* need something here to check for ceilings
    */
    bool ceiling = false;
    public Transform ceilingCheck;
    float ceilingRadius = 0.2f;
    public LayerMask whatIsCeiling;

    /* check if we are sliding; not need because we use two colliders, one for head and torso, one for legs.
     * Upon slide, head and torso collision box is disabled which allows for slide under game objects
    */
    //public float slideForce = 7000f; //not used, but could be to change the slide speed?
    bool sliding = false;
    public float maxSlideTime = 1.0f;  //adjust this along with sampling in animation window to control the slide
    [SerializeField]
    GameObject SlideCollider;  //reference to the collider game object

    //**********RUNES**************
    public int runes = 0;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("StartGame", false);
        isJumpRunning = false;
        maxJumpTime = 0.25f;
        jumpTime = 0.0f;
        move = 0;
    }
	
    void FixedUpdate()
    {
        //Debug.Log("players runes " + runes);

        groundCeilingCheck();
        if(startGame)
        {
            if (move == 0 && Input.anyKey)
            {
                move = 1;
                anim.SetBool("StartGame", true);  //start the run animation on key press, needed to smooth beginning fall in test scene
            }

            jump();
            slideFromJump();
        }

        //set variable for animator; always running
        anim.SetFloat("Speed", 1);// Mathf.Abs(move));

        //set variable for animator; set the vertical speed to play the jump animations from the Blend Tree
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }

    // Update is called once per frame
    void Update() {
        //set velocity of player to the right
        if (startGame) {
            //uhh just ignore the red line.
            sword.GetComponent<SwordCutsceneScript>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
            /*if(move == 1)
            {
                //uhh just ignore the red line.
                sword.GetComponent<SwordCutsceneScript>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
            }*/

            //non-physics
            if (ceiling)
                slide();
            if (!sliding && Input.GetKey(KeyCode.LeftControl) && !isJumpRunning)
            {
                slide();
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) || (!ceiling && sliding))
            {
                anim.SetBool("Slide", false);
                sliding = false;
                anim.SetBool("Ground", true);
                GetComponent<BoxCollider2D>().enabled = true;
            }
            if(transform.position.y < -5)
            {
                gOverScript.gameOver();
            }
        }
    }

    public float getYAxis()
    {
        return transform.position.y;
    }
    public void setRunesToZero()
    {
        runes = 0;
    }

    private void groundCeilingCheck()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //set variable for animator to queue animation
        anim.SetBool("Ground", grounded);
        playerIsGrounded = grounded;

        //check to see if player has touched a ceiling
        ceiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsCeiling);
        anim.SetBool("Ceiling", ceiling);
        //Debug.Log(ceiling);
    }

    private void jump()
    {
        if (grounded && Input.GetKey(KeyCode.Space) && !isJumpRunning)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce * 3.5f);
            jumpTime += Time.deltaTime;
            anim.SetBool("Ground", false);
            isJumpRunning = true;
        }
        else if (isJumpRunning)
        {
            if (!Input.GetKey(KeyCode.Space) || jumpTime >= maxJumpTime)
            {
                isJumpRunning = false;
                jumpTime = 0.0f;
            }
            else
            {
                jumpTime += Time.deltaTime;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (jumpForce / jumpTime) * 2f);
            }
        }
    }

    private void slideFromJump()
    {
        if (!grounded && Input.GetKeyDown(KeyCode.LeftControl))
        {
            //slideTimer = 0f;
            anim.SetBool("Slide", true);
            sliding = true;
            GetComponent<Rigidbody2D>().AddForce(Physics2D.gravity * 1.5f, ForceMode2D.Impulse);
        }
    }

    private void slide()
    {
        //sliding while holding control. When you release control, player stops sliding
        GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("Slide", true);
        sliding = true;
    }
}
