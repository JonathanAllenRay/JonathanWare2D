using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntsManager : MinigameManager {


    private bool success = false;
    // Update is called once per frame

    // Use this for initialization
    void Start()
    {
        Time.timeScale += timeScaleMod;
    }

    void Update () {
        GameTimeUpdate(success);
	}

    public void Stunted()
    {
        success = true;
    }
}
