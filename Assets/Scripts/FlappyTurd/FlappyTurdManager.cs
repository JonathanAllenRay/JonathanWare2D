using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyTurdManager : MonoBehaviour {
    private GameObject[] plungers;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = true;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        plungers = GameObject.FindGameObjectsWithTag("Plungers");
        plungers[Random.Range(0, 2)].SetActive(false);
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

    public void Failed()
    {
        success = false;
    }

    IEnumerator Result()
    {
        if (success)
        {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level1TapGames");
    }
}
