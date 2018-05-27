using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEscapeManager : MinigameManager {

    private GameObject[] exitBarriers;

    public GameObject ballGameObject;
    private EscapeBall ball;

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
        GameTimeUpdate(success);
    }

    public void Escaped()
    {
        success = true;
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
        //UnityEngine.SceneManagement.SceneManager.LoadScene(LevelSetVars.SetScenePath);
    }
}
