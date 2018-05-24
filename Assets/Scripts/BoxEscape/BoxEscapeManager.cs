using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEscapeManager : MonoBehaviour {

    private GameObject[] exitBarriers;

    public GameObject ballGameObject;
    private EscapeBall ball;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    private bool success = false;

    // Use this for initialization
    void Start()
    {
        ball = ballGameObject.GetComponent<EscapeBall>();
        ballGameObject.transform.position = new Vector2(ballGameObject.transform.position.x + Random.Range(-3.0f, 3.0f), 
            ballGameObject.transform.position.y);
        Time.timeScale += timeScaleMod;
        exitBarriers = GameObject.FindGameObjectsWithTag("Barrier");
        exitBarriers[Random.Range(0, exitBarriers.Length)].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.gravity = 30.0f * Input.acceleration.normalized;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (ball.HasEscaped())
            {
                success = true;
            }
            if (!ended)
            {
                Debug.Log(success);
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
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level1TapGames");
    }
}
