using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour { 

    public float time;
    public float delay;
    public bool boss = false;
    protected bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;


    protected void GameTimeUpdate(bool success)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                Debug.Log(success);
                StartCoroutine(SetManager.Result(success, delay, boss));
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    protected void GameTimeUpdateNoTime(bool success)
    { 
        StartCoroutine(SetManager.Result(success, delay, boss));
    }
}
