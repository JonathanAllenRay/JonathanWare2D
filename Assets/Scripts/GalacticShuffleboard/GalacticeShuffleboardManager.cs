using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticeShuffleboardManager : MinigameManager {

    public GameObject target;

    private bool success = false;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        int num = Random.Range(0, 3);
        if (num == 1)
        {
            target.transform.Translate(Vector2.right*1.5f);
        }
        else if (num == 2)
        {
            target.transform.Translate(-Vector2.right*1.5f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
    }

    public void SetSuccess()
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
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level1TapGames");
    }
}
