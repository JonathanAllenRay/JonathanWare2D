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
    public int maxGameIndex = 10;
    public int bossIndex = 10;
    private int currentGameIndex;
    private int gamesPlayed;

    private bool endless = false;

    // Use this for initialization
    void Start () {
        if (LevelSetVars.ResetOnNextSetLoad)
        {
            SetupSet();
        }
        SetupText(); 

        if (LevelSetVars.Lives <= 0)
        {
            LostSet();
        }
        else if (LevelSetVars.GamesPlayed >= gamesToPlay && !LevelSetVars.BossFightWon && !LevelSetVars.Endless)
        {
            Debug.Log("Games played cap reached");
            LevelSetVars.PlayedGame();
            StartCoroutine(SceneDelayWrapper(bossIndex));
        }
        else if (LevelSetVars.GamesPlayed < gamesToPlay || LevelSetVars.Endless)
        {
            PickNewScene();
        }
        else
        {
            // You won apparently
        }
    }

    private void SetupText()
    {


        if (LevelSetVars.Lives <= 0)
        {
            livesText.text = "You lost";
        }
        else if (LevelSetVars.BossFightWon)
        {
            livesText.text = "Winner";
        }
        else
        {
            livesText.text = "Lives: " + LevelSetVars.Lives;
        }
        gamesPlayedText.text = "Games Played: " + LevelSetVars.GamesPlayed;
    }

    public void PickNewScene()
    {
        LevelSetVars.PlayedGame();
        if (LevelSetVars.Endless)
        {
            int size = LevelSetVars.UnusedGameIndices.Count;
            int tempIndex = Random.Range(0, size);
            StartCoroutine(SceneDelayWrapper(LevelSetVars.UnusedGameIndices[tempIndex]));
        }
        else if (!LevelSetVars.Endless && LevelSetVars.UnusedGameIndices.Count > 0)
        {
            int index = Random.Range(0, LevelSetVars.UnusedGameIndices.Count);
            int val = LevelSetVars.UnusedGameIndices[index];
            LevelSetVars.UnusedGameIndices.RemoveAt(index);
            StartCoroutine(SceneDelayWrapper(val));

        }
        else
        {
            throw new System.Exception("Shouldn't reach here");
        }
    }

    IEnumerator SceneDelayWrapper(int sceneIndex)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneIndex);
    }

    private void SetupSet()
    {
        LevelSetVars.UnusedGameIndices = new List<int>();
        Debug.Log("Init num: " + LevelSetVars.UnusedGameIndices.Count);
        Debug.Log("Mindex" + minGameIndex);
        Debug.Log("Maxdex" + maxGameIndex);
        for (int i = minGameIndex; i < maxGameIndex; i++)
        {
            LevelSetVars.UnusedGameIndices.Add(i);
        }
        Debug.Log("Init num: " + LevelSetVars.UnusedGameIndices.Count);
        LevelSetVars.ResetOnNextSetLoad = false;
        LevelSetVars.Lives = lives;
        LevelSetVars.GamesPlayed = 0;
        LevelSetVars.GamesToPlay = gamesToPlay;
        LevelSetVars.GamesWon = 0;
        LevelSetVars.Endless = endless;
        LevelSetVars.BossFightWon = false;
    }
    
    public void LostSet()
    {
        LevelSetVars.ResetOnNextSetLoad = true;
        // Go to "end screen or some shit"
    }
}
