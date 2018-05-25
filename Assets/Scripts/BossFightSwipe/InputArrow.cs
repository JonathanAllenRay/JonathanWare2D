using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputArrow : MonoBehaviour {

    public SwipeDirection inputDir;
    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowRight;
    public GameObject arrowLeft;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDirection(SwipeDirection sd)
    {
        inputDir = sd;
        if (sd == SwipeDirection.Up)
        {
            arrowUp.SetActive(true);
        }
        else if (sd == SwipeDirection.Right)
        {
            arrowRight.SetActive(true);
        }
        else if (sd == SwipeDirection.Down)
        {
            arrowDown.SetActive(true);
        }
        else if (sd == SwipeDirection.Left)
        {
            arrowLeft.SetActive(true);
        }
    }

    public SwipeDirection GetArrowDir()
    {
        return inputDir;
    }
}
