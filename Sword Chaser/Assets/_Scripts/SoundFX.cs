using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public HUDscript hud;
    public AudioSource audioSource;
    public AudioClip audioClipCoin;
    public AudioClip audioClipRune;
    public AudioClip audioClipSword;

    public AudioClip audioClipLevel_01;

    private void Start()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClipLevel_01);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "coin_19")
        {
            GameObject go = GameObject.Find("Main Camera");
            HUDscript hud = (HUDscript)go.GetComponent(typeof(HUDscript));
            //hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            hud.IncreaseScore(1);

            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipCoin);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Rune")
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipRune);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Sword")
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipSword);
        }
    }
}
