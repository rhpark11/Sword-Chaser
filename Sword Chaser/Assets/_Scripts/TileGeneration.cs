using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour {
    public GameObject[] thePlatforms;
    public GameObject[] theEnemies;
    public Transform generationPoint;
    public float distanceBetweenPlatforms;
    public float distanceEnemyPlat;

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
        platFormWidths = new float[thePlatforms.Length];// gets new platforms
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
            distanceBetweenPlatforms = Random.Range(platformdDistanceBetweenMin, platformDistanceBetweenMax);
            platFormSelector = Random.Range(0, thePlatforms.Length);//picks a random platform to spawn
            enemySelector = Random.Range(0, theEnemies.Length);//picks a random enemy to spawn
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight; //the platforms can't go off the camera
            }
            else if(heightChange <minHeight)
            {
                heightChange = minHeight; //the platforms can't go off the camera
            }
            transform.position = new Vector3(transform.position.x + (platFormWidths[platFormSelector])/2 + distanceBetweenPlatforms, heightChange, transform.position.z);//the position of the new platform
            Instantiate(theEnemies[enemySelector], new Vector3(transform.position.x,transform.position.y+distanceEnemyPlat,transform.position.z), transform.rotation);//instantiate the enemy
            Instantiate(thePlatforms[platFormSelector], transform.position, transform.rotation);//instantiates the platform
        }
    }
}
