using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTimeManager : MonoBehaviour {

    public GameObject leftSpawn;
    public GameObject rightSpawn;

    private bool success = true;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    public GameObject leftAlien;
    public GameObject rightAlien;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        InvokeRepeating("SpawnEnemy", 0.0f, 1.2f);
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

    void SpawnEnemy()
    {
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(leftAlien, leftSpawn.transform.position, leftSpawn.transform.rotation);
        }
        else
        {
            Instantiate(rightAlien, rightSpawn.transform.position, rightSpawn.transform.rotation);
        }
    }

    private void Result()
    {

    }

    public void EarthDestroyed()
    {
        success = false;
        Debug.Log("Earth is dead");
    }
}
