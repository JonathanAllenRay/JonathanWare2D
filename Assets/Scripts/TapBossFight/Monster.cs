
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public TapBossFightManager tbm;

    public GameObject target;

    public GameObject blast;

    public GameObject shotPoint;

    public GameObject shootingArm;

    public GameObject shotPoint2;

    public GameObject shootingArm2;

    private bool dirSwap = false;

    public float health = 20.0f;

    private bool dead = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("ShootBlast", 0.5f, 0.7f);
        InvokeRepeating("ChangeDirection", 3.0f, 3.0f);

	}
	
	// Update is called once per frame
	void Update () {
        shootingArm.transform.right = -(target.transform.position - shootingArm.transform.position);
        shootingArm2.transform.right = -(target.transform.position - shootingArm2.transform.position);
        if (!dirSwap && !dead)
        {
            gameObject.transform.Translate(Vector2.up * 1.0f * Time.deltaTime);

        }
        else if (dirSwap && !dead)
        {
            gameObject.transform.Translate(-Vector2.up * 1.0f * Time.deltaTime);
        }
    }

    private void ShootBlast()
    {
        GameObject newBullet = Instantiate(blast, shotPoint.transform.position, shotPoint.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(-shootingArm.transform.right * 50.0f);

        GameObject newBullet2 = Instantiate(blast, shotPoint2.transform.position, shotPoint2.transform.rotation);
        newBullet2.GetComponent<Rigidbody2D>().AddForce(-shootingArm2.transform.right * 50.0f);
    }

    private void ChangeDirection()
    {
        dirSwap = !dirSwap;
    }

    public void TakeHit()
    {
        health -= 1.0f;
        if (health <= 0.0f)
        {
            tbm.YouKilledIt();
            CancelInvoke();
            dead = true;
        }
    }

    public void CeaseFire()
    {
        CancelInvoke("ShootBlast");
    }
}
