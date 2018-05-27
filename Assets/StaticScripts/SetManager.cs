using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetManager : MonoBehaviour {

    public static IEnumerator Result(bool success, float delay, bool isBoss)
    {
        if (success && isBoss)
        {
            LevelSetVars.BeatBoss();
        }
        else if (success && !isBoss)
        {
            LevelSetVars.WonGame();
        }
        else if (!success)
        {
            LevelSetVars.LostLife();
        }
        else
        {
            throw new System.Exception("Shouldn't reach here");
        }
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelSetVars.SetScenePath);
    }
}
