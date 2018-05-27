using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingLeg : MonoBehaviour {

    public float yFreeze = 1.08f;

    public float speed = 10.0f;

    bool stomped = false;
    bool bottom = false;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Down) && !stomped)
        {
            stomped = true;
        }
        if (stomped && !bottom)
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
            if (transform.position.y <= yFreeze)
            {
                bottom = true;
            }
        }
    }
}
