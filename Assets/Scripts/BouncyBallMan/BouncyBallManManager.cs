using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallManManager : MinigameManager {

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

    public void EndReached()
    {
        success = true;
    }
}
