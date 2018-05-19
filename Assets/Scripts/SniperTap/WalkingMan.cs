using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMan : MonoBehaviour {

    public float speed;
    private bool walk = false;
    private bool dead = false;
    public bool flipped = false;
    private bool inSight = false;
    private bool shot = false;
    public GameObject bmAlive;

    public GameObject flash;

    public GameObject gameManager;



    // Use this for initialization
    void Start() { 


        speed = Random.Range(6.0f, 8.0f);
        if (flipped)
        {
            speed = -speed;
        }
        float delay = Random.Range(0.1f, .6f);
        Invoke("StartWalking", delay);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (inSight && !shot)
            {
                BecomeDead();
                gameManager.GetComponent<SniperTapManager>().TangoDown();
            }
            if (!shot)
            {
                shot = true;
                Instantiate(flash, transform.position, transform.rotation);
            }
        }
        if (walk && !dead)
        {
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (dead)
        {
            gameObject.transform.Translate(-Vector2.up * 5.0f * Time.deltaTime);
        }
    }

    void StartWalking()
    {
        walk = true;
    }

    void BecomeDead()
    {
        dead = true;
        bmAlive.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inSight = true;
        Debug.Log("Colliding");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        inSight = true;
        Debug.Log("Colliding");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inSight = false;
    }
}
