using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticeShuffleboardManager : MonoBehaviour {

    public GameObject target;

    private bool successPending = false;
    private bool success = false;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;


    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        int num = Random.Range(0, 3);
        if (num == 1)
        {
            target.transform.Translate(Vector2.right*1.5f);
        }
        else if (num == 2)
        {
            target.transform.Translate(-Vector2.right*1.5f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            success = successPending;
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

    public void SetSuccess(bool onTarget)
    {
        successPending = true;
    }

    private void Result()
    {

    }
}
