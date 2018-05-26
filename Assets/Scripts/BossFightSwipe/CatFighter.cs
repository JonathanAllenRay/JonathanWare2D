using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFighter : MonoBehaviour {

    public GameObject firePoint;

    public Animator ani;

    public GameObject fireball;
    public GameObject ultFireball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartFireball()
    {
        ani.SetTrigger("Fireball");
        Debug.Log("shooting one fireball");
    }

    public void StartUltimateFireball()
    {
        ani.SetTrigger("UltimateMove");
    }

    public void ShootFireball()
    {
        Instantiate(fireball, firePoint.transform.position, firePoint.transform.rotation);
    }

    public void ShootUltimateFireball()
    {
        Instantiate(ultFireball, firePoint.transform.position, firePoint.transform.rotation);
    }
}
