using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaker : MonoBehaviour {

    public float jumpForce = 300.0f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public GameOver gameover;
    private bool jump;

    // Use this for initialization
    void Start () {
        grounded = true;
        gameover = GameObject.Find("GameOverController").GetComponent<GameOver>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(jump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        if (grounded && collider.tag == "Player")
        {
            jump = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (collider.tag == "Sword" && collider.GetComponent<SwordScript>().playerHasSword)
        {
            jump = true;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameover.gameOver();
            Destroy(collision.gameObject, 0.01f);
        }   
    }
}
