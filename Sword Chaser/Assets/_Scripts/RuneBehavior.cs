using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBehavior : MonoBehaviour {


    private bool PlusOneRune = true;

    private float elapsedTime = 0.0f;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Sin(elapsedTime) * 0.6f, 0);
	}
    
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
