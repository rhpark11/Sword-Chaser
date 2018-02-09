using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaker : MonoBehaviour {

    public float jumpForce = 200f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public GameOver gameover;

    // Use this for initialization
    void Start () {
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        if (grounded && collision.tag == "Player")
        {            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello collision");
        if (collision.gameObject.tag == "Player")
        {
            gameover.gameOver();
            Destroy(collision.gameObject, 0.01f);
        }
        
    }
}
