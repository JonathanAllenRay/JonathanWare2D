using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour {

    public UnityEngine.UI.Text livesText;
    public UnityEngine.UI.Text gamesPlayedText;

    public int lives = 3;
    public int gamesToPlay = 10;
    public int minGameIndex = 0;
    public int maxGameIndex = 12;
    private int currentGameIndex;
    private int gamesPlayed;

    private bool endless = false;

    // Use this for initialization
    void Start () {
        if (LevelSetVars.ResetOnNextSetLoad)
        {
            SetupSet();
        }
        livesText.text = "Lives: " + LevelSetVars.Lives;
        gamesPlayedText.text = "Games Played: " + LevelSetVars.GamesPlayed;
        if (LevelSetVars.Lives <= 0)
        {
            LostSet();
        }
        if (LevelSetVars.GamesPlayed == gamesToPlay)
        {
            // Do Boss Level
        }
        else
        {
            PickNewScene();
        }
    }

    public void PickNewScene()
    {
        LevelSetVars.PlayedGame();
        if (LevelSetVars.UnusedGameIndices.Count >= 0)
        {
            int index = Random.Range(0, LevelSetVars.UnusedGameIndices.Count);
            LevelSetVars.UnusedGameIndices.RemoveAt(index);
            StartCoroutine(SceneDelayWrapper(index));
        }
    }

    IEnumerator SceneDelayWrapper(int index)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }

    public void WonMinigame(bool won)
    {
        if (won) {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        if (LevelSetVars.Lives <= 0)
        {
            LostSet();
        }
    }

    private void SetupSet()
    {
        LevelSetVars.UnusedGameIndices = new List<int>();
        for (int i = minGameIndex; i < maxGameIndex; i++)
        {
            LevelSetVars.UnusedGameIndices.Add(i);
        }
        LevelSetVars.ResetOnNextSetLoad = false;
        LevelSetVars.Lives = lives;
        LevelSetVars.GamesPlayed = 0;
        LevelSetVars.GamesToPlay = gamesToPlay;
        LevelSetVars.GamesWon = 0;
        LevelSetVars.Endless = endless;
    }
    
    public void LostSet()
    {
        LevelSetVars.ResetOnNextSetLoad = true;
        // Go to "end screen or some shit"
    }
}
