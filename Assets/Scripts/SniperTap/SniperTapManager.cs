using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTapManager : MonoBehaviour {

    private bool success = false;

    public GameObject bm1;
    public GameObject bm2;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        if (Random.Range(0,2) == 1)
        {
            bm2.SetActive(false);
        }
        else
        {
            bm1.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                StartCoroutine(Result());
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    public void TangoDown()
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelSetVars.SetScenePath);
    }
}
