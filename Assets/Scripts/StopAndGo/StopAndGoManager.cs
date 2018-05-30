using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightColor
{
    Red, Yellow, Green, None
}

public class StopAndGoManager : MinigameManager {

    public StopAndGoRunner runner;

    public GameObject green;
    public GameObject yellow;
    public GameObject red;

    private LightColor color = LightColor.Green;

    private bool aboutToStop = true;

    private bool success = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("NextLight", Random.Range(1.0f, 1.2f), Random.Range(.5f, .8f));
	}
	
	// Update is called once per frame
	void Update () {
        if (color == LightColor.Red)
        {
            red.SetActive(true);
            green.SetActive(false);
            yellow.SetActive(false);
        }
        else if (color == LightColor.Yellow)
        {
            red.SetActive(false);
            green.SetActive(false);
            yellow.SetActive(true);
        }
        else if (color == LightColor.Green)
        {
            red.SetActive(false);
            green.SetActive(true);
            yellow.SetActive(false);
        }
        GameTimeUpdate(success);

	}

    void NextLight()
    {
        if (aboutToStop)
        {
            if (color == LightColor.Green)
            {
                color = LightColor.Yellow;
            }
            else if (color == LightColor.Yellow)
            {
                color = LightColor.Red;
                aboutToStop = false;
            }
        }
        else
        {
            if (color == LightColor.Red)
            {
                color = LightColor.Green;
                aboutToStop = true;
            }
        }
    }

    public LightColor GetColor()
    {
        return color;
    }

    public void MadeIt()
    {
        success = true;
    }

    public float GetTime()
    {
        return time;
    }
}
