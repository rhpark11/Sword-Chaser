using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public HUDscript hud;
    public AudioSource audioSource;
    public AudioClip audioClip;
	
	void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "coin_19")
        {
            GameObject go = GameObject.Find("Main Camera");
            HUDscript hud = (HUDscript)go.GetComponent(typeof(HUDscript));
            //hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            hud.IncreaseScore(1);
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
            Destroy(other.gameObject);
        }
	}
}
