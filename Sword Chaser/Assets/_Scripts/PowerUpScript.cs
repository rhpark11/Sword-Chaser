using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    //HUDscript hud;
    public AudioSource soundSource;
    public AudioClip sound;
    private bool hasPlayed = false;

    void Start()
    {
        //tickSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            //hud.IncreaseScore(100);
            soundSource.PlayOneShot(sound);
            Destroy(this.gameObject);
        }
    }
}
