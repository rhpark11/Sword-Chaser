using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GenereateTile : MonoBehaviour {

    public TileBase tileA;
    public Vector3Int position;
    public int distanceX;
    public int distanceY;
    private int frames;
    public int generateXFrame = 5;
    public int platLength = 3;
    private int genframe;
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
       
        genframe = generateXFrame;
    }
    void Update()
    {
        frames += 1;

        //Debug.Log(frames);
        if (genframe == frames)
        {
            Tilemap tilemap = GetComponent<Tilemap>();
            for(int i = 0; i<platLength; ++i)
                tilemap.SetTile(position += new Vector3Int(distanceX+i, distanceY, 0), tileA);
            
            genframe +=generateXFrame;
        }
       // Tilemap tilemap = GetComponent<Tilemap>();
       // tilemap.SetTile(position += new Vector3Int(2, 0, 0), tileA);
    }
}
