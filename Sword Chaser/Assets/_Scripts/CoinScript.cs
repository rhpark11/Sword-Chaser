using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClipCoin;
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player1");
        audioSource = player.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D triggeredBy)
    {
        if(triggeredBy.gameObject.tag == "Player")
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipCoin);
            
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Destroy(this.gameObject, 0.01f);
        }
    }
}
