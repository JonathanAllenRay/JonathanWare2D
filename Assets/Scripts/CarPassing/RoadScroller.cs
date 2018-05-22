using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScroller : MonoBehaviour {

    public float speed = 10.0f;

    public float resetPoint = -35.0f;
    private Vector2 originalPoint;

	// Use this for initialization
	void Start () {
        originalPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector2.up * speed * Time.deltaTime);
        if (transform.position.y <= resetPoint)
        {
            transform.position = originalPoint;
        }
    }
}
