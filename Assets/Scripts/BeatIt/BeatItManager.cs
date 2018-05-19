using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatItManager : MonoBehaviour {

    public AudioSource snare;

    public AudioSource right;
    public AudioSource wrong;

    public GameObject rightCheck;
    public GameObject wrongX;

    public float quarterNote = .4f;
    public float eightNote = .2f;
    public float sixteenthNote = .1f;

    public float timeAllowance = .15f;

    private float secondNoteTime;
    private float thirdNoteTime;
    private float lastNoteTime;

    private bool playerTurn = false;

    bool success = false;

    public GameObject snareDrum;
    private Drum sd;


    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        sd = snareDrum.GetComponent<Drum>();
        Invoke("PlayInitialBeat", 0.5f);
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

    void PlayInitialBeat()
    {
        sd.AnimateSticks();
        snare.Play();
        int selectNote = Random.Range(0, 3);
        float delay = 0;
        if (selectNote == 0)
        {
            delay = quarterNote;
        }
        else if (selectNote == 1)
        {
            delay = eightNote;
        }
        else if (selectNote == 2)
        {
            delay = sixteenthNote;
        }
        secondNoteTime = delay;
        Invoke("PlaySecondNote", delay);
    }

    void PlaySecondNote()
    {
        sd.AnimateSticks();
        snare.Play();
        int selectNote = Random.Range(0, 3);
        float delay = 0;
        if (selectNote == 0)
        {
            delay = quarterNote;
        }
        else if (selectNote == 1)
        {
            delay = eightNote;
        }
        else if (selectNote == 2)
        {
            delay = sixteenthNote;
        }
        thirdNoteTime = delay + secondNoteTime;
        Invoke("PlayThirdNote", delay);
    }

    void PlayThirdNote()
    {
        sd.AnimateSticks();
        snare.Play();
        int selectNote = Random.Range(0, 3);
        float delay = 0;
        if (selectNote == 0)
        {
            delay = quarterNote;
        }
        else if (selectNote == 1)
        {
            delay = eightNote;
        }
        else if (selectNote == 2)
        {
            delay = sixteenthNote;
        }
        lastNoteTime = delay + thirdNoteTime;
        Invoke("PlayLastNote", delay);
    }

    void PlayLastNote()
    {
        sd.AnimateSticks();
        snare.Play();
        playerTurn = true;
    }

    public float GetNoteTime(int n)
    {
        if (n == 2)
        {
            return secondNoteTime;
        }
        else if (n == 3)
        {
            return thirdNoteTime;
        }
        else if (n == 4)
        {
            return lastNoteTime;
        }
        return 0.0f;
    }

    public float GetAllowance()
    {
        return timeAllowance;
    }

    public void PlaySnare()
    {
        snare.Play();
    }

    public bool IsPlayerTurn()
    {
        return playerTurn;
    }

    public void Failure()
    {
        wrong.Play();
        wrongX.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Success()
    {
        success = true;
        right.Play();
        rightCheck.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Result()
    {

    }
}
