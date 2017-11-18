using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    /*
    //need something here to check for ceilings
    bool ceiling = false;
    public Transform ceilingCheck;
    float ceilingRadius = 0.2f;
    public LayerMask whatIsCeiling;
    */
    public float jumpForce = 500f;
    public float slideForce = 7000f;

    //check if we are sliding
    bool sliding = false;
    //store slide time
    float slideTimer = 0f;
    public float maxSlideTime = 1.0f;
    //reference to the collider game object
    [SerializeField]
    GameObject SlideCollider;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);  //detects failing and jumping vertical speed
        float move = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", 1);//Mathf.abs(move) replaced with 1

        //ceiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsCeiling);
        
        //control player movement
        //GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        /*
        if(!sliding && !anim.GetCurrentAnimatorStateInfo(0).IsTag("slide"))
        {
         GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);//move * maxSpeed replaced with 3
        }
        else
        {
         GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
        }
        */
        /*
        //turn the character left and right
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        */
    }
    /*
    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        //slide
        if (grounded && Input.GetKeyDown(KeyCode.LeftControl) && !sliding)
        {
            slideTimer = 0f;
            anim.SetBool("Slide", true);
            
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //SlideCollider.GetComponent<BoxCollider2D>().enabled = true;
            sliding = true;
        }
        if(sliding)
        {
            slideTimer += Time.deltaTime;

            if(slideTimer > maxSlideTime)
            {
                sliding = false;
                anim.SetBool("Slide", false);
                gameObject.GetComponent<Collider2D>().enabled = true;
                //SlideCollider.GetComponent<Collider2D>().enabled = false;
            }
        }

    }
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
}
