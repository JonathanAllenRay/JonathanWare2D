using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonAnimal : MonoBehaviour {

    private bool popped = false;
    public float speed;
    public GameObject balloonAnimal;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public AudioSource popSource;

    public GameObject poppedBalloon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!popped)
        {
            balloonAnimal.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        popped = true;
        rb.gravityScale = 1;
        bc.isTrigger = false;
        Instantiate(poppedBalloon, gameObject.transform.position, gameObject.transform.rotation);
        popSource.Play();
        GameObject.Find("GameManager").GetComponent<BalloonAnimalsManager>().SavedCat();
        Destroy(gameObject);    
    }
}
