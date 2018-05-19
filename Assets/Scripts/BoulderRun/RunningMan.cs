using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMan : MonoBehaviour {

    public float speed;

    public float speedMod;

    public float speedFade;

    public Rigidbody2D rb;

    public Animator ani;

    private bool dead = false;

    public BoulderRunManager brm;

    // Use this for initialization
    void Start () {
        InvokeRepeating("DecreaseSpeed", 0f, 0.075f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            speedMod += speedFade*3;
        }
        if (!dead)
        {
            gameObject.transform.Translate(Vector2.right * (speed + speedMod) * Time.deltaTime);
        }
    }

    void DecreaseSpeed()
    {

        if (speedMod <= speedFade)
        {
            speedMod = 0f;
        }
        else
        {
            speedMod -= speedFade;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Boulder")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            ani.SetTrigger("Dead");
            dead = true;
        }
        else if (collision.transform.gameObject.name == "FinishLine" && !dead)
        {
            brm.MadeIt();
        }
    }
}
