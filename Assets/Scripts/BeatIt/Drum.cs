using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour {

    public GameObject gameManager;
    private BeatItManager bm;
    private float startTime;

    public Animator sticks;



    private int taps;

	// Use this for initialization
	void Start () {
        bm = gameManager.GetComponent<BeatItManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (bm.IsPlayerTurn())
        {
            bm.PlaySnare();
            AnimateSticks();
            taps++;
            if (taps == 1)
            {
                startTime = Time.time;
            }
            else if (taps == 2)
            {
                if ((startTime + TimeOffset()) < startTime + bm.GetNoteTime(2) + bm.GetAllowance()
                    && (startTime + TimeOffset()) > startTime + bm.GetNoteTime(2) - bm.GetAllowance())
                {
                    Debug.Log("on time");
                }
                else
                {
                    Debug.Log("fail");
                    Failure();
                }
            }
            else if (taps == 3)
            {
                if ((startTime + TimeOffset()) < startTime + bm.GetNoteTime(3) + bm.GetAllowance()
                    && (startTime + TimeOffset()) > startTime + bm.GetNoteTime(3) - bm.GetAllowance())
                {
                    Debug.Log("on time");
                }
                else
                {
                    Debug.Log("fail");
                    Failure();
                }
            }
            else if (taps == 4)
            {
                if ((startTime + TimeOffset()) < startTime + bm.GetNoteTime(4) + bm.GetAllowance()
                    && (startTime + TimeOffset()) > startTime + bm.GetNoteTime(4) - bm.GetAllowance())
                {
                    Debug.Log("on time,winner");
                    Success();
                }
                else
                {
                    Debug.Log("fail");
                    Failure();
                }
            }
        }
    }

    private float TimeOffset()
    {
        return Time.time - startTime;
    }

    private void Failure()
    {
        bm.Failure();
    }

    private void Success()
    {
        bm.Success();   
    }

    public void AnimateSticks()
    {
        sticks.SetTrigger("PlayStick");
    }
}
