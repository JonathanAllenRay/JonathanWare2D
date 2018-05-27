using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTapManager : MinigameManager {

    private bool success = false;

    public GameObject bm1;
    public GameObject bm2;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        if (Random.Range(0,2) == 1)
        {
            bm2.SetActive(false);
        }
        else
        {
            bm1.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
    }

    public void TangoDown()
    {
        success = true;
    }
}
