using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinToWinManager : MonoBehaviour {

    public Rigidbody2D spinnerBody;

    public float victoryVelocity = 3400f;
    private bool success = false;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;
    // Use this for initialization
    void Start()
    {
        Time.timeScale += timeScaleMod;
    }


    // Update is called once per frame
    void Update() {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (Mathf.Abs(spinnerBody.angularVelocity) > victoryVelocity)
            {
                success = true;
            }
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                Debug.Log(success);
                StartCoroutine(Result());
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
        if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Left))
        {
            spinnerBody.AddTorque(-SwipeManager.Instance.GetForce()*20f);
        }
        else if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Right))
        {
            spinnerBody.AddTorque(SwipeManager.Instance.GetForce()*20f);
        }
        else if (SwipeManager.Instance.GetDir() != SwipeDirection.None)
        {
            spinnerBody.AddTorque(-SwipeManager.Instance.GetForce() * 20f);
        }

    }

    IEnumerator Result()
    {
        Debug.Log(success);
        if (success)
        {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level2SwipeGames");
    }

}
