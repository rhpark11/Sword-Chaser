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

    private GameObject sword;

    private void Start()
    {
        audioSource.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClipLevel_01);
        sword = GameObject.Find("Sword");
    }

    void OnTriggerEnter2D(Collider2D other) {

        bool hasSword = sword.GetComponent<SwordScript>().playerHasSword;
        if (other.tag == "coin_19")
        {
            GameObject go = GameObject.Find("Main Camera");
            //HUDscript hud = (HUDscript)go.GetComponent(typeof(HUDscript));
            //hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            hud.IncreaseScore(1);

            //audioSource.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioClipCoin);
            //Destroy(other.gameObject);
        }
        else if (other.tag == "Rune")
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipRune);
        }
        //else if (/*other.tag == "Sword" &&*/ sword.GetComponent<SwordScript>().playerHasSword)
        //else if(other.transform.IsChildOf(this.gameObject.transform))
        else if(hasSword)
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClipSword);
        }
        //Debug.Log("player has sword " + sword.GetComponent<SwordScript>().playerHasSword);
        Debug.Log("player has sword " + hasSword);
        Debug.Log(other.tag);
    }
}
