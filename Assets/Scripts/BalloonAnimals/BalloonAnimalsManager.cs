using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonAnimalsManager : MonoBehaviour {

    public int numToSpawn;
    public GameObject balloonAnimals;
    private int catsSaved;

    public AudioSource meow;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

	// Use this for initialization
	void Start () {
        Time.timeScale += timeScaleMod;
		for (int i = 0; i < numToSpawn; i++)
        {
            Vector2 loc = new Vector2(Random.Range(-.9f, .9f), Random.Range(.05f, .15f));
            Instantiate(balloonAnimals, loc, transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                StartCoroutine(Result());
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }

    }

    public void SavedCat()
    {
        catsSaved++;
    }

    IEnumerator Result()
    {
        Debug.Log("Getting result");
        bool success = false;
        if (catsSaved == numToSpawn)
        {
            success = true;
            Debug.Log("Winner");
            meow.Play();
        }
        else
        {
            Debug.Log("Loser");
        }
        if (success)
        {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(LevelSetVars.SetScenePath);
    }

}
