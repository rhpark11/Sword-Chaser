using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {

    public Camera mainCamera;
    public float speed = 0.25f;
    public float scrollWidth = 26.5f;

    private Vector2 startPosition;

    float newPosition;
    Vector2 newPos;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        //scroll background slowly
        newPosition = Mathf.Repeat(Time.time * speed, scrollWidth);
        transform.position = startPosition + (Vector2.left * newPosition);
        //if background posisiton x is behind camera, send it back to camera position
        if ((transform.position.x + scrollWidth) < mainCamera.transform.position.x)
        {
            newPos = transform.position;
            newPos.x += scrollWidth;
            startPosition = newPos-(Vector2.left * newPosition);
        }
    }
}
