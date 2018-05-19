using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour {

    public Rigidbody2D rb;

    public GameObject rotRef;

    public GameObject sjm;

    public AudioSource hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(rotRef.transform.up * 400.0f);
        float displacement = Random.Range(-150.0f, 150.0f);
        rb.AddTorque(Random.Range(-20.0f, 20.0f));
        rb.AddForce(rotRef.transform.right * displacement);
        hit.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Help I've fallen and I can't get up");
        sjm.GetComponent<SoccerJuggleManager>().Lose();
    }
}
