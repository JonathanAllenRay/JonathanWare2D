using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("CleanupBullet", 3.0f);	
	}
	
	// Update is called once per frame
	void Update () {



    }

    public void CleanupBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Monster>().TakeHit();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
