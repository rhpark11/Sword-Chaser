using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    bool startGame = false; //start the motion of the player
    float start = 0;//don't start running until player moves the character

    /* use these to check if grounded to run jump or fall states
    */
    public float jumpForce = 500f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

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
    float slideTimer = 0f;  //store slide time
    public float maxSlideTime = 1.0f;  //adjust this along with sampling in animation window to control the slide
    [SerializeField]
    GameObject SlideCollider;  //reference to the collider game object
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("StartGame", false);
    }
	
    void FixedUpdate()
    {
        //check to see if player has touched the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //set variable for animator to queue animation
        anim.SetBool("Ground", grounded);

        //check to see if player has touched a ceiling
        ceiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsCeiling);
        anim.SetBool("Ceiling", ceiling);

        float move = Input.GetAxis("Horizontal");
        if (move != 0) {
            startGame = true;
            start = 1;
            anim.SetBool("StartGame", true);  //start the run animation on key press, needed to smooth beginning fall in test scene
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

        //if player is sliding and ceiling is above, then keep sliding
        if (!sliding && Input.GetKeyDown(KeyCode.LeftControl))
        {
            slideTimer = 0f;
            anim.SetBool("Slide", true);

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //SlideCollider.GetComponent<BoxCollider2D>().enabled = true;  //not need as of now see above slide comments
            sliding = true;
        }
        if (sliding)
        {
            slideTimer += Time.deltaTime;

            if (slideTimer > maxSlideTime && !ceiling)
            {
                sliding = false;
                anim.SetBool("Slide", false);
                gameObject.GetComponent<Collider2D>().enabled = true;
                //SlideCollider.GetComponent<Collider2D>().enabled = false;  //not need as of now see above slide comments
            }
        }
    }
}
