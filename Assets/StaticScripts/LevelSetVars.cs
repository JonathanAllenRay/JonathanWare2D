using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetVars : MonoBehaviour {

    private static int lives;
    private static int currentGameIndex;
    private static int minGameIndex;
    private static int maxGameIndex;
    private static int gamesPlayed;
    private static int gamesToPlay;
    private static int gamesWon;

    private static bool endless;
    private static bool bossFightWon = false;

    // If true, reset all vars to sets default on Load.
    // Used for if we need to load a new set or if
    // we need to are restarting. Should be reset to
    // false every time a reset is called so we don't
    // double reset.
    // Initially true because the first time you play a set
    // it needs to be set up.
    private static bool resetOnNextSetLoad = true;

    private static List<int> unusedGameIndices;

    public static List<int> UnusedGameIndices
    {
        get
        {
            return unusedGameIndices;
        }
        set
        {
            unusedGameIndices = value;
        }
    }


    public static int Lives {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    public static int CurrentGameIndex
    {
        get
        {
            return currentGameIndex;
        }
        set
        {
            currentGameIndex = value;
        }
    }

    public static int MinGameIndex
    {
        get
        {
            return minGameIndex;
        }
        set
        {
            minGameIndex = value;
        }
    }

    public static int MaxGameIndex
    {
        get
        {
            return maxGameIndex;
        }
        set
        {
            maxGameIndex = value;
        }
    }

    public static int GamesPlayed
    {
        get
        {
            return gamesPlayed;
        }
        set
        {
            gamesPlayed = value;
        }
    }

    public static int GamesToPlay
    {
        get
        {
            return gamesToPlay;
        }
        set
        {
            gamesToPlay = value;
        }
    }

    public static int GamesWon
    {
        get
        {
            return gamesWon;
        }
        set
        {
            gamesWon = value;
        }
    }

    public static bool Endless
    {
        get
        {
            return endless;
        }
        set
        {
            endless = value;
        }
    }

    public static bool ResetOnNextSetLoad {
        get
        {
            return resetOnNextSetLoad;
        }
        set
        {
            resetOnNextSetLoad = value;
        }
    }

    public static bool BossFightWon
    {
        get
        {
            return bossFightWon;
        }
        set
        {
            bossFightWon = value;
        }
    }

    public static void WonGame()
    {
        GamesWon++;
    }

    public static void PlayedGame()
    {
        GamesPlayed++;
    }

    public static void LostLife()
    {
        Lives--;
    }

    public static void GainLife()
    {
        Lives++;
    }

    public static void BeatBoss()
    {
        bossFightWon = true;
        WonGame();
    }
}
