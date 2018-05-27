using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBossFightManager : MinigameManager {

    public bool success = false;

    public Monster monster;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
    }

    public void YouDied()
    {
        Debug.Log("Dead");
        monster.CeaseFire();
    }

    public void YouKilledIt()
    {
        success = true;
        Debug.Log("Hero");
    }
}
