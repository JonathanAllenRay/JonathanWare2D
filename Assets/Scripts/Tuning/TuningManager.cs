using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MinigameManager {

    public AudioSource cNote;
    public AudioSource eNote;
    public AudioSource gNote;

    public GameObject knob;

    private AudioSource tunedSource;
    private bool success = false;

    public float snap;
    public float sensitivity;
    public float tolerance;

	// Use this for initialization
	void Start () {
        int n = Random.Range(0, 3);
        if (n == 0)
        {
            tunedSource = cNote;
        }
        else if (n == 1)
        {
            tunedSource = eNote;
        }
        else
        {
            tunedSource = gNote;
        }
        float mod = Random.Range(-0.5f, .5f);
        while (mod < .08 && mod > -.08)
        {
            mod = Random.Range(-0.5f, .5f);
        }
        tunedSource.pitch += mod;
        knob.transform.eulerAngles = new Vector3(0, 0, (1.0f - tunedSource.pitch) * 200f);
    }

    // Update is called once per frame
    void Update () {
        if (Mathf.Abs(1f - tunedSource.pitch) < snap)
        {
            tunedSource.pitch = 1f;
            knob.transform.eulerAngles = new Vector3(0, 0, (1.0f - tunedSource.pitch) * 200f);
        }
        AdjustTuning();
        if (Mathf.Abs(1f - tunedSource.pitch) < tolerance)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        GameTimeUpdate(success);


    }

    void AdjustTuning()
    {
        tunedSource.pitch += Input.acceleration.x * sensitivity;
        if (tunedSource.pitch < 0.5f)
        {
            tunedSource.pitch = 0.5f;
        }
        else if (tunedSource.pitch > 1.5f)
        {
            tunedSource.pitch = 1.5f;
        }
        knob.transform.eulerAngles = new Vector3(0, 0, (1.0f - tunedSource.pitch) * 200f);

    }
}
