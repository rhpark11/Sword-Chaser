using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour {
    public GameObject[] thePlatforms;
    public GameObject[] theEnemies;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;
    public float platformdDistanceBetweenMin;
    public float platformDistanceBetweenMax;

    private int platFormSelector;
    private int enemySelector;
    private float[] platFormWidths;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    void Start()
    {
        platFormWidths = new float[thePlatforms.Length];
        for (int i = 0; i<thePlatforms.Length; ++i)
        {
            platFormWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }
    void Update()
    {
        if (transform.position.x <generationPoint.position.x)
        {
            distanceBetween = Random.Range(platformdDistanceBetweenMin, platformDistanceBetweenMax);
            platFormSelector = Random.Range(0, thePlatforms.Length);
            enemySelector = Random.Range(0, theEnemies.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange <minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platFormWidths[platFormSelector])/2 + distanceBetween, heightChange, transform.position.z);
            Instantiate(theEnemies[enemySelector], transform.position, transform.rotation);
            Instantiate(thePlatforms[platFormSelector], transform.position, transform.rotation);
        }
    }
}
