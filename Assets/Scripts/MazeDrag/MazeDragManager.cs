using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDragManager : MinigameManager {

    public GameObject[] obstacles;

    private bool success = false;

	// Use this for initialization
	void Start () {
        Time.timeScale += timeScaleMod;
        obstacles = GameObject.FindGameObjectsWithTag("Barrier");
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].transform.Translate(Vector2.up * Random.Range(-2f, 2f));
        }
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
	}

    public void MadeIt()
    {
        success = true;
    }

    public void Dead()
    {
        success = false;
    }
}
