using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTimeManager : MinigameManager {

    public GameObject leftSpawn;
    public GameObject rightSpawn;

    private bool success = true;

    public GameObject leftAlien;
    public GameObject rightAlien;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        InvokeRepeating("SpawnEnemy", 0.0f, 1.2f);
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
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

    public void EarthDestroyed()
    {
        success = false;
        Debug.Log("Earth is dead");
    }
}
