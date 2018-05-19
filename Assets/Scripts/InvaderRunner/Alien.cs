using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {



    bool canJump = true;
    public Rigidbody2D alienRb;

    public GameObject splat;

    public GameObject explosion;

    bool fallen = false;

    public float speed = 11.0f;

    public GameObject gameManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!fallen && canJump && Input.GetMouseButtonDown(0))
        {
            alienRb.AddForce(transform.up * 300.0f);
            canJump = false;
        }
        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Earth")
        {
            Instantiate(explosion, collision.transform.gameObject.transform.position, collision.transform.gameObject.transform.rotation);
            Destroy(collision.transform.gameObject);
            gameManager.GetComponent<InvaderRunnerManager>().EarthDestroyed();
        }
        else
        {
            Vector2 temp = new Vector2(transform.position.x - .5f, transform.position.y);
            Instantiate(splat, temp, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Fell()
    {
        fallen = true;
    }

    
}
