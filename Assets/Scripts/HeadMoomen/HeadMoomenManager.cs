using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMoomenManager : MinigameManager {

    private bool success = true; 
    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
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

    public void Failed()
    {
        success = false;       
    }
}
