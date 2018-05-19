using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,

    //Diags

    LeftDown = 9,
    LeftUp = 5,
    RightDown = 10,
    RightUp = 6,
}

public class SwipeManager : MonoBehaviour
{

    // Class based on https://www.youtube.com/watch?v=poeXGuQ7eUo
    // See video for help.
    private static SwipeManager instance;
    public static SwipeManager Instance { get { return instance; } }
    public SwipeDirection Direction { set; get;}

    private Vector3 touchPos;
    private Vector2 angleVector;
    private float swipeThreshX = 50.0f;
    private float swipeThreshY = 100.0f;

    public float forceBase = 100.0f;
    private float lastSwipeForce;
    private float touchStart;


    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Direction = SwipeDirection.None;
        angleVector = Vector2.zero;
        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Input.mousePosition;
            touchStart = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastSwipeForce = forceBase - (Time.time - touchStart);
            lastSwipeForce = (lastSwipeForce < 0) ? 0 : lastSwipeForce;
            Vector2 deltaSwipe = touchPos - Input.mousePosition;
            angleVector = Input.mousePosition - touchPos;
            if (Mathf.Abs(deltaSwipe.x) > swipeThreshX)
            {
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
            }
            if (Mathf.Abs(deltaSwipe.y) > swipeThreshY)
            {
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
            }
        }
    }

    public SwipeDirection GetDir()
    {
        return Direction;
    }

    public Vector2 GetSwipeVector()
    {
        return angleVector;
    }

    public float GetForce()
    {
        return lastSwipeForce;
    }
}
