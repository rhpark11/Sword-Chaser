using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform canvas;

    private void Start()
    {
        if (canvas.gameObject.activeInHierarchy == true)
            canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
