using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStompManager : MinigameManager {

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale += timeScaleMod;
    }

	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
    }

    public void AlienSmashed()
    {
        success = true;
    }
}
