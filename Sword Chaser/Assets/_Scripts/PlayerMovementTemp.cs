using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTemp : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
	}
}
