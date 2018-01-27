using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    [SerializeField]
    public float amplitude = 1.0f; //may need later to variy vertical travel of sword
    public float period, phase = 0; //may need later

    public bool startMoving = false;

    public bool playerHasSword = false;
    public float swordTime = 5;
    private float swordTimer = 0;
    public GameObject player;
    private bool swordSetup = false;
    private float rockingMotion = 0;

    private float frequency, angularFrequency, elapsedTime = 0;
    
    private float x, y = 0;
    private float acceleration = 3.0f;
    private float initialVelocity = 8.0f;

    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
        frequency = 1 / Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {


        if (startMoving && !playerHasSword)//player first encounters the sword or swordTimer is up
        {
            x = elapsedTime;
            y = Mathf.Sin(x);
            elapsedTime += Time.deltaTime;

            if(elapsedTime > 1.0) //2.0)
            {
                acceleration = 0;
                initialVelocity = 3;
            }

            transform.position += new Vector3(initialVelocity + acceleration * elapsedTime, y, 0) * Time.deltaTime;
            
            //if sin(x) is near 0 then it's okay to change the amplitude of the traveling wave pattern
            //make a range of amplitudes that goes from small to large, sequential or random maybe possilbe, use an array with random index calls
        }

        if(playerHasSword)
        {
            //Debug.Log("player has sword " + playerHasSword);
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
                
                //reset the variables for sword escape
                elapsedTime = 0;
                initialVelocity = 8;
                acceleration = 3;

                //reset the rotation
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (swordTimer > 0)
            {
                //sword rocking back and forth
                elapsedTime += Time.deltaTime;
                rockingMotion = Mathf.Sin(9 * elapsedTime);
                int flipAxis = 1;
                if (rockingMotion < 0)
                {
                    flipAxis = -1;
                }
                float randomAngle = Random.Range(0.4f, 0.7f);
                          

                Debug.Log(flipAxis);
                //this.gameObject.transform.RotateAround( player.transform.position, Vector3.up, 10 * rockingMotion);//this is kinda cool
                this.gameObject.transform.RotateAround(player.transform.position, new Vector3(0, 0, flipAxis), randomAngle);
                //this.gameObject.transform.rotation = Quaternion.Euler(0, 0, flipAxis); //not rotating about the right point
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
        }
    }
}
