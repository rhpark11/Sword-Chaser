using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        //if (Time.timeScale == 0) Time.timeScale = 1;
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

}
