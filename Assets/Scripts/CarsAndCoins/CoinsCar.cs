using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCar : MonoBehaviour {

    public float speed;
    public CarsAndCoinsManager cacm;

	// Update is called once per frame
	void Update () {
        float turnSpeed = Input.acceleration.x;
        if (turnSpeed < -.3f)
        {
            turnSpeed = -.3f;
        }
        else if (turnSpeed > .3f)
        {
            turnSpeed = .3f;
        }
        transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime * 800f);
        transform.Translate(Vector2.up * Time.deltaTime * speed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cacm.GetCoin();
        Destroy(collision.transform.gameObject);
    }
}
