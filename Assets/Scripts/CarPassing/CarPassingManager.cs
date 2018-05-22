using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPassingManager : MonoBehaviour {

    public GameObject spawnLeft;

    public GameObject spawnRight;

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = true;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        InvokeRepeating("SpawnCar", 0.1f, 1.85f);
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

    void SpawnCar()
    {
        int car = Random.Range(0, 3);
        int lane = Random.Range(0, 2);
        GameObject theCar = null;
        if (car == 0)
        {
            theCar = car1;
        }
        if (car == 1)
        {
            theCar = car2;
        }
        if (car == 2)
        {
            theCar = car3;
        }
        if (lane == 0)
        {
            Instantiate(theCar, spawnLeft.transform.position, spawnLeft.transform.rotation);
        }
        else
        {
            Instantiate(theCar, spawnRight.transform.position, spawnRight.transform.rotation);
        }
    }

    private void Result()
    {

    }

    public void Crashed()
    {
        success = false;
    }
}
