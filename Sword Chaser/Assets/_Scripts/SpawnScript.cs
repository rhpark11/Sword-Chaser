using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 10f;
    public float spawnMax = 10f;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", 8,Random.Range(spawnMin, spawnMax));
    }
    
    void Spawn ()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], this.gameObject.transform.position, Quaternion.identity);
        
	}
}
