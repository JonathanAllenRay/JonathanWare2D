using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRunManager : MonoBehaviour {

    private bool success = false;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;

    }

    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                Result();
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    public void HeDed()
    {
    }

    private void Result()
    {

    }

    public void MadeIt()
    {
        success = true;
        Debug.Log("Made It");
    }
}
