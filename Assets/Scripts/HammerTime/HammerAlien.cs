﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAlien : MonoBehaviour {

    public float speed;
    public bool movingRight;

    public GameObject splatter;
    public GameObject bang;


    // Update is called once per frame
    void Update() {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Hammer" && collision.transform.gameObject.GetComponent<Hammer>().IsMoving())
        {
            Instantiate(splatter, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.transform.gameObject.tag == "Earth")
        {
            collision.transform.gameObject.GetComponent<HammerTimeEarth>().EarthDie();
            Instantiate(bang, collision.transform.gameObject.transform.position, collision.transform.gameObject.transform.rotation);
            Destroy(collision.transform.gameObject);
        }
    }
}
