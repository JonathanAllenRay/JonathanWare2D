using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsDrift : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
