using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTossManager : MonoBehaviour {

    private bool success = false;

    public GameObject can;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;
    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        float xTemp = can.transform.position.x;
        can.transform.position = new Vector2(Random.Range(xTemp - 1.0f, xTemp + 1.0f), can.transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                Debug.Log(success);
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

    private void Result()
    {

    }

    public void InTheCan()
    {
        success = true;
        Debug.Log("In the can");
    }


}
