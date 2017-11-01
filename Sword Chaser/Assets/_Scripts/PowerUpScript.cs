using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    HUDscript hud;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            hud = GameObject.Find("Main Camera").GetComponent<HUDscript>();
            hud.IncreaseScore(100);
            Destroy(this.gameObject);
        }
    }
}
