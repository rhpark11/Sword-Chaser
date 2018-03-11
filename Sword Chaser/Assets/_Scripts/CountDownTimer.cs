using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    public int count = 3;
    public Text countText;
    public bool start = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
            countText.text = count.ToString();
        else if(count ==0)
        {
            countText.text = "GO!";
        }
        else if(count <=-1)
        {
            StopCoroutine("CountDown");
            start = true;
        }
    }

    public void skip()
    {
        count = 0;
    }

    IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            count--;
        }

    }
}
