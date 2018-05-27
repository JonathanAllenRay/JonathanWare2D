using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitItManager : MinigameManager {
    public Animator leftLeg;
    public Animator rightLeg;
    public Rigidbody2D mainBody;

    private bool leftUp = false;
    private bool rightUp = false;

    private bool success = false;
    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
    }

    // Update is called once per frame
    void Update () {
		if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Left))
        {
            leftLeg.SetTrigger("Move");
            leftUp = true;
        }
        if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Right))
        {
            rightLeg.SetTrigger("Move");
            rightUp = true;
        }
        if (rightUp && leftUp)
        {
            mainBody.bodyType = RigidbodyType2D.Dynamic;
            success = true;
        }
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
}
