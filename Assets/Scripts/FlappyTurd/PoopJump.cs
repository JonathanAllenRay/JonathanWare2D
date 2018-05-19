using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopJump : MonoBehaviour {

    public Rigidbody2D rb;

    public AudioSource poopFlap;

    public GameObject poopExplode;

    public float speed = 1.0f;

    public GameObject gameManager;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(transform.up * 300.0f);
            poopFlap.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GetComponent<FlappyTurdManager>().Failed();
        Instantiate(poopExplode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
