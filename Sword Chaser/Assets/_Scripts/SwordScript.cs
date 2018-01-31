using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    [SerializeField]
    public float amplitude = 1.0f; //may need later to variy vertical travel of sword
    public float period, phase = 0; //may need later

    public bool startMoving = false;

    public GameObject player;

    //****Player has the sword variables
    public bool playerHasSword = false;
    public float swordTime = 5;
    
    private float swordTimer = 0;
    private bool adjustSwordUp = true;
    private bool adjustSwordDown = true;
    private bool resetSwordDynamics = false;
    private bool swordSetup = false;
    private float rockingMotion = 0;
    private int numberOfRotations = 0;
    //****
    //number of runs to collect
    public int RunesToCollect = 3;
    private int runes = 0;

    private float frequency, angularFrequency, elapsedTime = 0;
    
    private float x, y = 0;
    private float acceleration = 3.0f;
    private float initialVelocity = 8.0f;

    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
        frequency = 1 / Time.deltaTime;
        player = GameObject.Find("Player1");
	}
	
	// Update is called once per frame
	void Update () {

        runes = player.GetComponent<PlayerController>().runes;
        //Debug.Log("runes "+runes);
        

        if (startMoving && !playerHasSword)//player first encounters the sword or swordTimer is up
        {
            x = elapsedTime;
            y = Mathf.Sin(x);
            elapsedTime += Time.deltaTime;

            if(elapsedTime > 3.0)
            {
                acceleration = 0;
                initialVelocity = 3;

                if (runes == RunesToCollect - 2)
                {
                    initialVelocity = 2;
                }
                if (runes == RunesToCollect - 1)
                {
                    initialVelocity = 1;
                }
                if (runes == RunesToCollect)
                {
                    initialVelocity = 0;
                }
            }
            
            //Debug.Log("sword velocity " + initialVelocity);
            transform.position += new Vector3(initialVelocity + acceleration * elapsedTime, y, 0) * Time.deltaTime;

            //if sin(x) is near 0 then it's okay to change the amplitude of the traveling wave pattern
            //make a range of amplitudes that goes from small to large, sequential or random maybe possilbe, use an array with random index calls

            //**********************RESET THE BOX COLLIDER2D
//this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if(playerHasSword)
        {
            
            if(swordSetup)
            {
                this.gameObject.transform.SetParent(player.transform);
                transform.position = new Vector3(player.transform.position.x , player.transform.position.y, 0);
                transform.Translate(0.9f, -0.1f, 0);
                transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), 1.2f);

                swordTimer = swordTime;  //set the swordTimer to public variable Xseconds
                swordSetup = false;  //sword no longer needs to be setup
            }

            swordTimer -= Time.deltaTime;  //decreament a timer for the time player gets to hold a sword
            if (swordTimer <= 0 ) //if timer runs out, let the sword escape
            {
                swordTimer = swordTime;  //reset the timer for the next time player get the sword
                startMoving = true;  //run the sword escape code

                this.gameObject.transform.SetParent(null);  //break the parent child relationship
                this.gameObject.transform.Translate(0.5f, 0, 0);  //break the collision by translation in local space
                
                playerHasSword = false;  //player no longer has the  sword
                //Debug.Log("player has sword " + playerHasSword);

                //reset the variables for sword escape
                elapsedTime = 0;
                initialVelocity = 8;
                acceleration = 3;

                //reset the rotation
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else// if (swordTimer > 0)
            {
                float player_Y_velocity = player.GetComponent<Rigidbody2D>().velocity.y;

                //player is jumping
                if (player_Y_velocity > 2.0)
                {
                    if (adjustSwordDown)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, -15f);
                        transform.Translate(0, -0.1f, 0);
                        adjustSwordDown = false;
                        resetSwordDynamics = true;
                    }
                }
                else //player is grounded or at peak of jump
                {
                    if(resetSwordDynamics)
                    {
                        if (!adjustSwordDown)
                        {
                            transform.Translate(0, 0.1f, 0);
                            transform.rotation = Quaternion.Euler(0, 0, 0f);
                            adjustSwordDown = true;   
                        }
                        resetSwordDynamics = false;
                    }
                    //sword rocking back and forth
                    if(PlayerController.playerIsGrounded)
                    {
                        if(numberOfRotations > 0)
                        {
                            transform.RotateAround(player.transform.position, Vector3.forward, numberOfRotations * -0.8f);
                            numberOfRotations = 0;
                        }

                        elapsedTime += Time.deltaTime;
                        rockingMotion = Mathf.Sin(9 * elapsedTime);
                        int flipAxis = 1;
                        if (rockingMotion < 0)
                        {
                            flipAxis = -1;
                        }
                        float randomAngle = Random.Range(0.4f, 0.7f);

                        //this.gameObject.transform.RotateAround( player.transform.position, Vector3.up, 10 * rockingMotion);//this is kinda cool
                        this.gameObject.transform.RotateAround(player.transform.position, new Vector3(0, 0, flipAxis), randomAngle);
                    }
                    else
                    {
                        numberOfRotations++;
                        this.gameObject.transform.RotateAround(player.transform.position, Vector3.forward, 0.8f);
                    }
                    
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           startMoving = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHasSword = true;
            swordSetup = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //Debug.Log("boxColl2D enabled? " + this.gameObject.GetComponent<BoxCollider2D>().enabled);
        }
    }
}
