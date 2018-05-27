using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStompManager : MonoBehaviour {

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = false;

    // Use this for initialization
    void Start()
    {
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
                Debug.Log(success);
                //StartCoroutine(SetManager.Result(success, 1.0f, false));
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    public void AlienSmashed()
    {
        success = true;
    }
}
