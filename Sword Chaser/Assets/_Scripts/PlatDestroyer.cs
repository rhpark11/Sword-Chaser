using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestroyer : MonoBehaviour {
    public GameObject platDestruction;
    public string destructorName = "Destroyer";
	// Use this for initialization
	void Start () {
        
        platDestruction = GameObject.Find(destructorName);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <platDestruction.transform.position.x)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}
}
