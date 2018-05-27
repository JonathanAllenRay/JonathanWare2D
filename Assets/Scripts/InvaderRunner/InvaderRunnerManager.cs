using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderRunnerManager : MinigameManager {

    public GameObject[] stairs;

    public GameObject alien;


    private bool success = false;

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
        GameTimeUpdate(success);
    }

    public void EarthDestroyed()
    {
        success = true;
    }
}
