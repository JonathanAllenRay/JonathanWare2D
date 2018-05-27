using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyTurdManager : MinigameManager {
    private GameObject[] plungers;

    private bool success = true;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        plungers = GameObject.FindGameObjectsWithTag("Plungers");
        plungers[Random.Range(0, 2)].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
    }

    public void Failed()
    {
        success = false;
    }
}
