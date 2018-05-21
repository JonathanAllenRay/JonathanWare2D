using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitItManager : MonoBehaviour {
    public Animator leftLeg;
    public Animator rightLeg;
    public Rigidbody2D mainBody;

    private bool leftUp = false;
    private bool rightUp = false;


    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = false;
    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
    
    }

    // Update is called once per frame
    void Update () {
		if (SwipeManager.Instance.GetDir() == SwipeDirection.Left)
        {
            leftLeg.SetTrigger("Move");
            leftUp = true;
        }
        if (SwipeManager.Instance.GetDir() == SwipeDirection.Right)
        {
            rightLeg.SetTrigger("Move");
            rightUp = true;
        }
        if (rightUp && leftUp)
        {
            mainBody.bodyType = RigidbodyType2D.Dynamic;
            success = true;
        }
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
}
