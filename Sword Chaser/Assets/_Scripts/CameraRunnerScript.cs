using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunnerScript : MonoBehaviour {

    public Transform player;
    //public GameObject player;
    //public Vector3 offset;
	// Use this for initialization
	void Start () {
        //offset = transform.position - player.transform.position;
	}

    // Update is called once per frame
    void Update() {
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(player.position.x + 6, 0, -10);
    }
}
