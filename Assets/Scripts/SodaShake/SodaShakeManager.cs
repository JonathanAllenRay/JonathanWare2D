using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaShakeManager : MinigameManager {

    public GameObject sodaCan;
    public GameObject spray;

    private float lastX = 0.0f;

    private float lastY = 0.0f;

    private float shakeVal = 0f;

    private bool success = false;

	// Use this for initialization
	void Start () {
        Time.timeScale += timeScaleMod;
    }

    // Update is called once per frame
    void Update () {
        float xDiff = Mathf.Abs(Input.acceleration.x - lastX);
        float yDiff = Mathf.Abs(Input.acceleration.y - lastY);
        lastX = Input.acceleration.x;
        lastY = Input.acceleration.y;
        float shake = xDiff + yDiff;
        shakeVal += shake * 100f;
        Debug.Log(shakeVal);
        sodaCan.transform.eulerAngles = (Vector3.forward * Input.acceleration.x * Input.acceleration.y * 10f);
        if (shakeVal > 10000f)
        {
            spray.SetActive(true);
            success = true;
        }
        GameTimeUpdate(success);
    }
}
