using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    [SerializeField]
    public float amplitude = 1.0f; //may need later to variy vertical travel of sword
    public float period, phase = 0; //may need later

    public bool startMoving = false;

    private float frequency, angularFrequency, elapsedTime = 0;
    
    private float x, y = 0;
    private float acceleration = 3.0f;
    private float initialVelocity = 8.0f;

    // Use this for initialization
    void Start () {
        frequency = 1 / Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () {


        if (startMoving)
        {
            x = elapsedTime;
            y = Mathf.Sin(x);
            elapsedTime += Time.deltaTime;

            if(elapsedTime > 2.0)
            {
                acceleration = 0;
                initialVelocity = 3;
            }

            transform.position += new Vector3(initialVelocity + acceleration * elapsedTime, y, 0) * Time.deltaTime;
            
            //if sin(x) is near 0 then it's okay to change the amplitude of the traveling wave pattern
            //make a range of amplitudes that goes from small to large, sequential or random maybe possilbe, use an array with random index calls
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startMoving = true;
        }
    }
}
