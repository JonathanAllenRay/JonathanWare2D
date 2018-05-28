using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyGuy : MonoBehaviour {

    public Rigidbody2D rb;
    public BouncyBallManManager bbmm;

    public GameObject[] platforms;

	// Use this for initialization
	void Start () {
        platforms = GameObject.FindGameObjectsWithTag("Platforms");
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].transform.position = new Vector2(platforms[i].transform.position.x + Random.Range(-.5f, .5f), platforms[i].transform.position.y + Random.Range(-.5f, .5f));
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Input.acceleration.x * Time.deltaTime * 16f);
        transform.eulerAngles = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Platforms")
        {
            rb.AddForce(Vector2.up * 350f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bbmm.EndReached();
    }
}
