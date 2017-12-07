using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour {
    public GameObject plat;
    public Transform genPoint;
    public float distBetweenMin;
    public float distBetweenMax;
    private float distBetween;
    private float distHeight;
    public float maxHeight;
    public float minHeight;
    private float platWidth;
    private int platSelection;
    // Use this for initialization

    public GameObject[] platformsA;
	void Start () {
        
        platWidth = plat.GetComponent<BoxCollider2D>().size.x;
        Instantiate(platformsA[platSelection], transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
         if (transform.position.x <genPoint.position.x)
        {
            distBetween = Random.Range(distBetweenMin, distBetweenMax);
            distHeight = Random.Range(minHeight, maxHeight);

            transform.position = new Vector3(transform.position.x + platWidth + distBetween,
                transform.position.y, transform.position.z);

            platSelection = Random.Range(0, platformsA.Length);

            Instantiate(platformsA[platSelection], transform.position, transform.rotation);
        }
    }
}
