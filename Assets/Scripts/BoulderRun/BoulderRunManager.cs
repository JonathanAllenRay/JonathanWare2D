using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoulderRunManager : MinigameManager {

    private bool success = false;
    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
    }

    public void MadeIt()
    {
        success = true;
        Debug.Log("Made It");
    }
}
