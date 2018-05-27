using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerJuggleManager : MinigameManager {

    public bool success = true;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;

    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
    }

    public void Lose()
    {
        success = false;
    }
}
