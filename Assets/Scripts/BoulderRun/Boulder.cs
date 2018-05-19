using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.AddForce(transform.right * 550.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
