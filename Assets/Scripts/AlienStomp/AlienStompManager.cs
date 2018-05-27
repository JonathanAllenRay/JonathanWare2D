using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStompManager : MinigameManager {

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
