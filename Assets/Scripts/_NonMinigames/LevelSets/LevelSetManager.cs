using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSetManager : MonoBehaviour {
    public UnityEngine.UI.Text livesText;
    public UnityEngine.UI.Text gamesPlayedText;

    // Scene indices should have Minigames 0-N
    // Boss fights N+1-M
    // Else M+1-End

    public int lives = 3;
    private int gamesToPlay;
    public int minGameIndex = 0;
    public int maxGameIndex = 10;
    public int extraGamesToPlay = 0; // An extra game is a subset of all games
    public int bossIndex = 10;
    public float extraChance;
    private int currentGameIndex;
    private int gamesPlayed;
    public string setScenePath = "Scenes/LevelSets/Level1TapGames";

    public bool endless = false;

    // Use this for initialization
    void Start()
    {
        gamesToPlay = (maxGameIndex - minGameIndex) + extraGamesToPlay;
        if (LevelSetVars.ResetOnNextSetLoad)
        {
            LevelSetVars.SetupSet(minGameIndex, maxGameIndex, lives, endless, setScenePath);
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
            // You won apparently, do something here
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
        if (LevelSetVars.Endless)
        {
            int size = LevelSetVars.UnusedGameIndices.Count;
            int tempIndex = Random.Range(0, size);
            if (PlayExtraEndless())
            {
                LevelSetVars.PlayedGame();
                LevelSetVars.PlayedExtraGame();
                StartCoroutine(SceneDelayWrapper(Random.Range(0, minGameIndex)));
            }
            else
            {
                LevelSetVars.PlayedGame();
                StartCoroutine(SceneDelayWrapper(LevelSetVars.UnusedGameIndices[tempIndex]));
            }
        }
        else if (!LevelSetVars.Endless && LevelSetVars.GamesPlayed < gamesToPlay)
        {
            if (PlayExtra())
            {
                LevelSetVars.PlayedExtraGame();
                LevelSetVars.PlayedGame();
                StartCoroutine(SceneDelayWrapper(Random.Range(0, minGameIndex)));
            }
            else
            {
                LevelSetVars.PlayedGame();
                int index = Random.Range(0, LevelSetVars.UnusedGameIndices.Count);
                int val = LevelSetVars.UnusedGameIndices[index];
                LevelSetVars.UnusedGameIndices.RemoveAt(index);
                StartCoroutine(SceneDelayWrapper(val));
            }
        }
        else
        {
            throw new System.Exception("Shouldn't reach here");
        }
    }

    bool PlayExtra()
    {
        return (Random.Range(0.0f, 1.0f) < extraChance && LevelSetVars.ExtraGamesPlayed < extraGamesToPlay) || (LevelSetVars.UnusedGameIndices.Count == 0 && LevelSetVars.ExtraGamesPlayed < extraGamesToPlay);
    }

    bool PlayExtraEndless()
    {
        return Random.Range(0.0f, 1.0f) < extraChance;
    }

    IEnumerator SceneDelayWrapper(int sceneIndex)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneIndex);
    }


    public void LostSet()
    {
        LevelSetVars.ResetOnNextSetLoad = true;
        // Go to "end screen or some shit"
    }
}
