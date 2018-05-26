using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

    public Animator ani;

    public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Fizzle()
    {
        ani.SetTrigger("Fizzle");
    }

    public void CleanFizzle()
    {
        Destroy(gameObject);
    }
}
