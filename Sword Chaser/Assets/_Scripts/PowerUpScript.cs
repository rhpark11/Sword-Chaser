using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    //HUDscript hud;
    public AudioSource soundSource;
    public AudioClip sound;
    //private bool hasPlayed = false;

    void Start()
    {
        //tickSource = GetComponent<AudioSource>();
        //soundSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            //hud.IncreaseScore(100);

            //soundSource.GetComponent<AudioListener>().enabled = true;
            //soundSource.PlayOneShot(sound);

            soundSource.GetComponent<AudioSource>().PlayOneShot(sound);
            //AudioSource.PlayClipAtPoint(sound, transform.position);
            //yield return new WaitForSeconds(0.4f);  //only works in a co-routine
            //soundSource.Play();
            Destroy(this.gameObject);//destorys the audioSource so can't play the AudioClip
        }
    }
    
}