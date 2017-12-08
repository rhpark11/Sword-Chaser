using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaker : MonoBehaviour {

    public float jumpForce = 100f;
    
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    // Use this for initialization
    void Start () {
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("in on trigger");

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        if (grounded && collision.tag == "Player")
        {
            Debug.Log("in if grounded");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        
    }
}
