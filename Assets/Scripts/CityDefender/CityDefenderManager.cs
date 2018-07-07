using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDefenderManager : MinigameManager {

    public GameObject rocket;
    private bool success = true;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnRocket", 0.0f, .7f);
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
    }

    void SpawnRocket()
    {
        Vector2 pos = new Vector2(Random.Range(-4.5f, 4.5f), 6.3f);
        Instantiate(rocket, pos, transform.rotation);
    }

    public void CityDestroyed()
    {
        success = false;
    }
}
