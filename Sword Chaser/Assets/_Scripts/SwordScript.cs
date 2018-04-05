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
    private bool swordSetup = false;
    
    //number of runs to collect
    public int RunesToCollect = 3;
    private int runes = 0;

    private float elapsedTime = 0;

    public ParticleSystem ps;
    
    private float x, y = 0;
    private float acceleration = 3.0f;
    private float initialVelocity = 8.0f;
    private float decelerate = 0.0f; //this is a time variable
    private bool slowDown = true;

    public LayerMask whatIsGround;

    //public Quaternion originalRotationValue;

    // Use this for initialization
    void Start () {
        //frequency = 1 / Time.deltaTime;
        player = GameObject.Find("Player1");
        //ps = GetComponent<ParticleSystem>();
        //originalRotationValue = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if(player!=null)
            runes = player.GetComponent<PlayerController>().runes;        

        if (startMoving && !playerHasSword)//player first encounters the sword or swordTimer is up
        {
            x = elapsedTime;
            y = Mathf.Sin(x);
            elapsedTime += Time.deltaTime;

            if(elapsedTime > 1.3)
            {
                
                if (runes == RunesToCollect - 2)
                {
                    
                    if(slowDown && decelerate < 3.0f)
                    {
                        //print(decelerate);
                        decelerate += Time.deltaTime;
                        acceleration = -0.1f;
                    }
                    else
                    {
                        decelerate = 0.0f;
                        acceleration = 0.0f;
                        slowDown = false;
                    }
                    //initialVelocity = 2;
                }
                else if (runes == RunesToCollect - 1)
                {
                    //slowDown = true;
                    
                    if (decelerate < 3.0f)
                    {
                        //print(decelerate);
                        decelerate += Time.deltaTime;
                        acceleration = -0.1f;
                    }
                    else
                    {
                        //decelerate = 0.0f;
                        acceleration = 0.0f;
                        slowDown = true;
                    }
                    //initialVelocity = 1;
                }
                else if (runes == RunesToCollect)
                {
                    //acceleration = -0.1f;
                    
                    initialVelocity = 2;
                }
                else
                {
                    acceleration = 0.0f;
                    if(player!=null)
                        initialVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
                }                
            }
            //so the sword doesnt fall behind the player
            //we can do this or change it so that if it does, the sword goes all the way back
            //to the front.
            
            if(player != null && transform.position.x <= player.transform.position.x)
            {
                transform.position += new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, y, 0) * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(initialVelocity + acceleration * elapsedTime, y, 0) * Time.deltaTime;
            }
            
        }
        
        if(playerHasSword)
        {
            
            if(swordSetup)
            {
                this.gameObject.transform.SetParent(player.transform);
                transform.position = new Vector3(player.transform.position.x+0.5f , player.transform.position.y+0.3f, 0);
                transform.Translate(1.5f, -0.1f, 0);

                swordTimer = swordTime;  //set the swordTimer to public variable Xseconds
                swordSetup = false;  //sword no longer needs to be setup
            }

            swordTimer -= Time.deltaTime;  //decreament a timer for the time player gets to hold a sword
            if (swordTimer <= 0 ) //if timer runs out, let the sword escape
            {
                swordTimer = swordTime;  //reset the timer for the next time player get the sword
                startMoving = true;  //run the sword escape code

                this.gameObject.transform.SetParent(null);  //break the parent child relationship
                //this.gameObject.transform.SetPositionAndRotation(new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 0.3f, 0), originalRotationValue);
                this.gameObject.transform.Translate(1.3f, 0, 0);  //break the collision by translation in local space
                
                playerHasSword = false;  //player no longer has the  sword
                player.GetComponent<PlayerController>().canSlide = true;

                //reset the variables for sword escape
                elapsedTime = 0;
                initialVelocity = 8;
                acceleration = 3;

                player.GetComponent<PlayerController>().setRunesToZero(); //reset runes to make the sword fast again
                acceleration = 3.0f;
                initialVelocity = 8.0f;

                ps.Play();
                //ps.enableEmission = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//triggers don't interact with the physics system
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!startMoving && this.gameObject.GetComponent<CircleCollider2D>().enabled == true)
            {
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                startMoving = true;
            }
            else
            {
                playerHasSword = true;
                swordSetup = true;
                //ps.enableEmission = false;
                ps.Stop();
                player.GetComponent<PlayerController>().canSlide = false;
            }
        }
        else if(collision.gameObject.tag == "Enemy Faker" && playerHasSword && !collision.GetComponent<CircleCollider2D>().enabled)
        {
            Destroy(collision.gameObject, 0.01f);
        }
        else if (collision.gameObject.tag == "Enemy Jumper" && playerHasSword)
        {
            Destroy(collision.gameObject, 0.01f);
        }
        else if(collision.gameObject.tag == "Enemy Stationary" && playerHasSword)
        {
            Destroy(collision.gameObject, 0.01f);
        }
    }
}
