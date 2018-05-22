using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCars : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        //speed = Random.Range(2.0f, 3.0f);
        speed = 4.20f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector2.up * speed * Time.deltaTime);
    }
}
