﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderRunnerManager : MonoBehaviour {

    public GameObject[] stairs;

    public GameObject alien;


    private bool success = false;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        stairs = GameObject.FindGameObjectsWithTag("StairsSpace");
        int index = Random.Range(0, 3);
        for (int i = 0; i < stairs.Length; i++)
        {
            stairs[i].SetActive(false);
        }
        stairs[index].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                StartCoroutine(SetManager.Result(success, 1.0f, false));
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    public void EarthDestroyed()
    {
        success = true;
    }
}
