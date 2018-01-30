using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBehavior : MonoBehaviour {


    private bool PlusOneRune = true;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("in Rune collider");
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("in Player tag");
            collision.gameObject.GetComponent<PlayerController>().runes++;
            Destroy(this.gameObject);
        }
    }*/
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("in Rune collider");
        
        if (collision.gameObject.tag == "Player" && PlusOneRune)
        {
            //Debug.Log("in Player tag");
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<PlayerController>().runes++;
            PlusOneRune = false;
        }
    }
}
