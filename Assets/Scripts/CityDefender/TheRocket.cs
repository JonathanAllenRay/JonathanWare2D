﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRocket : MonoBehaviour {

    public float speed;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime * -Vector2.up);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Umbrella")
        {

        }
        else if (collision.transform.gameObject.name == "City")
        {

        }
    }
}
