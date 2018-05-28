using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFighter : MonoBehaviour {

    public GameObject firePoint;

    public Animator ani;

    public GameObject explosion;

    public GameObject fireball;
    public GameObject ultFireball;

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

    public void CatDead()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
