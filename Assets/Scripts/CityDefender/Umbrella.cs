using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour {

    private float yStart;

	// Use this for initialization
	void Start () {
        yStart = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = new Vector2(Camera.main.ScreenToWorldPoint(mousePosition).x, -1.11f);
        transform.position = objPosition;
    }
}
