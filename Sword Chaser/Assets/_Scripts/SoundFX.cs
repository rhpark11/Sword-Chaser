using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;
	
	void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "coin_19")
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
            Destroy(other.gameObject);
        }
	}
}
