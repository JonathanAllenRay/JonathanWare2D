using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityDefenderManager : MonoBehaviour {

    public GameObject rocket;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnRocket", 0.0f, .7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnRocket()
    {
        Vector2 pos = new Vector2(Random.Range(-4.5f, 4.5f), 6.3f);
        Instantiate(rocket, pos, transform.rotation);
    }
}
