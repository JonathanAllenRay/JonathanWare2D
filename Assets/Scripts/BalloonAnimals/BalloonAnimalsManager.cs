using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonAnimalsManager : MinigameManager {

    public int numToSpawn;
    public GameObject balloonAnimals;
    private int catsSaved;

    private bool success = false;

    public AudioSource meow;

	// Use this for initialization
	void Start () {
        Time.timeScale += timeScaleMod;
		for (int i = 0; i < numToSpawn; i++)
        {
            Vector2 loc = new Vector2(Random.Range(-.9f, .9f), Random.Range(.05f, .15f));
            Instantiate(balloonAnimals, loc, transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);

    }

    public void SavedCat()
    {
        catsSaved++;
        meow.Play();
        if (numToSpawn == catsSaved)
        {
            success = true;
        }
    }

}
