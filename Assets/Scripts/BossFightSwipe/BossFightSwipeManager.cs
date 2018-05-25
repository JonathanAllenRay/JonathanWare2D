﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightSwipeManager : MonoBehaviour {

    public GameObject catFighter;

    public GameObject inputArrow;

    public GameObject inputStartPoint;

    private List<GameObject> inputList = new List<GameObject>();

    private int inputIndex = 0;
    private int throws = 0;

	// Use this for initialization
	void Start () {
        SetupFireball();	
	}
	
	// Update is called once per frame
	void Update () {
        CheckComboInput();
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
        SetupFireball();
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
        if (SwipeManager.Instance.GetDir() != SwipeDirection.None)
        {
            if (SwipeManager.Instance.SwipingInDir(inputList[inputIndex].GetComponent<InputArrow>().GetArrowDir()))
            {
                inputList[inputIndex].SetActive(false);
                if (inputIndex >= inputList.Count-1)
                {
                    ClearInputs();
                    throws++;
                    if (throws == 3)
                    {
                        // Trigger ultimate
                    }
                    else if (throws < 2)
                    {
                        SetupFireball();
                        // Normal
                    }
                    else
                    {
                        SetupFireballSuper();
                    }
                }
                else
                {
                    inputIndex++;
                }
            }
        }
    }
}