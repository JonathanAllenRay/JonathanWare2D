using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjasVersusAliensManager : MinigameManager {

    private bool success = false;
    // Use this for initialization
    void Start()
    {
        Time.timeScale += timeScaleMod;
    }
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);

    }

    IEnumerator Result()
    {
        Debug.Log(success);
        if (success)
        {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level2SwipeGames");
    }

    public void UFODown()
    {
        success = true;
    }
}
