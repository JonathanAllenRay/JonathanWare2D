using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightSwipeManager : MinigameManager {

    public CatFighter catFighter;

    public GameObject inputArrow;

    public GameObject inputStartPoint;

    private List<GameObject> inputList = new List<GameObject>();

    private int inputIndex = 0;
    private int throws = 0;

    private bool success = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale += timeScaleMod;
        SetupFireball();	
	}
	
	// Update is called once per frame
	void Update () {
        CheckComboInput();
	}

    public void EndGame()
    {
        StartCoroutine(Result());
    }

    public void BossDestroyed()
    {
        success = true;
        EndGame();
    }

    void SetupFireball()
    {
        inputList.Clear();
        inputIndex = 0;
        for (int i = 0; i < 4 ; i++)
        {
            if (i == 3)
            {
                Vector2 temp = new Vector2(inputStartPoint.transform.position.x + (2.0f * i), inputStartPoint.transform.position.y);
                GameObject arrow = Instantiate(inputArrow, temp, inputStartPoint.transform.rotation);
                arrow.GetComponent<InputArrow>().SetDirection(SwipeDirection.Right);
                inputList.Add(arrow);
            }
            else
            {
                Vector2 temp = new Vector2(inputStartPoint.transform.position.x + (2.0f * i), inputStartPoint.transform.position.y);
                GameObject arrow = Instantiate(inputArrow, temp, inputStartPoint.transform.rotation);
                arrow.GetComponent<InputArrow>().SetDirection(RandomSwipeDirection());
                inputList.Add(arrow);
            }
        }
    }

    void SetupFireballSuper()
    {
        inputList.Clear();
        inputIndex = 0;
        for (int i = 0; i < 6; i++)
        {
            if (i == 5)
            {
                Vector2 temp = new Vector2(inputStartPoint.transform.position.x + (2.0f * i), inputStartPoint.transform.position.y);
                GameObject arrow = Instantiate(inputArrow, temp, inputStartPoint.transform.rotation);
                arrow.GetComponent<InputArrow>().SetDirection(SwipeDirection.Right);
                inputList.Add(arrow);
            }
            else
            {
                Vector2 temp = new Vector2(inputStartPoint.transform.position.x + (2.0f * i), inputStartPoint.transform.position.y);
                GameObject arrow = Instantiate(inputArrow, temp, inputStartPoint.transform.rotation);
                arrow.GetComponent<InputArrow>().SetDirection(RandomSwipeDirection());
                inputList.Add(arrow);
            }
        }
    }

    void MissedInput()
    {
        ClearInputs();
        if (throws == 3)
        {
            SetupFireballSuper();
        }
        else
        {
            SetupFireball();
        }
        inputIndex = 0;
    }

    void ClearInputs()
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            Destroy(inputList[i]);
        }
        inputList.Clear();
        inputIndex = 0;
    }

    SwipeDirection RandomSwipeDirection()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            return SwipeDirection.Left;
        }
        else if (i == 1) {
            return SwipeDirection.Down;
        }
        else
        {
            return SwipeDirection.Up;
        }
    }

    void CheckComboInput()
    {
        if (SwipeManager.Instance.GetDir() != SwipeDirection.None && inputList.Count > 0)
        {
            if (SwipeManager.Instance.SwipingInDir(inputList[inputIndex].GetComponent<InputArrow>().GetArrowDir()))
            {
                inputList[inputIndex].SetActive(false);
                if (inputIndex >= inputList.Count-1)
                {
                    throws++;
                    ClearInputs();
                    if (throws == 4)
                    {
                        // Trigger ultimate
                        catFighter.StartUltimateFireball();

                    }
                    else if (throws < 3)
                    {
                        catFighter.StartFireball();
                        SetupFireball();
                        // Normal
                    }
                    else
                    {
                        catFighter.StartFireball();
                        SetupFireballSuper();
                    }
                }
                else
                {
                    inputIndex++;
                }
            }
            else
            {
                MissedInput();
            }
        }
    }

    IEnumerator Result()
    {
        if (success)
        {
            LevelSetVars.BeatBoss();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        //SceneManager.LoadScene(LevelSetVars.SetScenePath);
    }
}
