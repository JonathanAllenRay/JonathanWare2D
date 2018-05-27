using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTossManager : MinigameManager {

    private bool success = false;

    public GameObject can;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        float xTemp = can.transform.position.x;
        can.transform.position = new Vector2(Random.Range(xTemp - 1.0f, xTemp + 1.0f), can.transform.position.y);
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

    public void InTheCan()
    {
        success = true;
        Debug.Log("In the can");
    }
}
