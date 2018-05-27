using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternDuelManager : MinigameManager {

    private bool canShoot = false;
    private bool success = false;
    private bool dead = false;

    public AudioSource bang;

    public GameObject heroCactus;
    public GameObject evilCactus;

    public GameObject muzzlePointHero;
    public GameObject muzzlePointEvil;

    public GameObject gun;
    public GameObject gunExplode;

    public GameObject muzzleFlash;
    public GameObject muzzleFlashEvil;

    private float timeToShoot = 0.4f;

    private void Start()
    {
        Time.timeScale += timeScaleMod;
    }

    private void Update()
    {
        GameTimeUpdate(success);
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsDead() && CanShoot() && !HasSuccess())
            {
                Success();
            }
            else if (!CanShoot() && !IsDead())
            {
                FailureTooEarly();
            }
        }
        if (canShoot && !success)
        {
            timeToShoot -= Time.deltaTime;
            if (!dead && timeToShoot <= 0)
            {
                FailureTooLate();
            }
        }
    }

    public void AllowShoot()
    {
        canShoot = true;
    }

    public bool CanShoot()
    {
        return canShoot;
    }

    public bool IsDead()
    {
        return dead;
    }

    public bool HasSuccess()
    {
        return success;
    }

    public void FailureTooEarly()
    {
        ExplodePlayer();
        dead = true;
        Debug.Log("Jumped the gun");

    }

    public void FailureTooLate()
    {
        ShootPlayer();
        dead = true;
        Debug.Log("Too slow!");
        Rigidbody2D rb = heroCactus.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.right * 1337.0f);
        rb.AddForce(transform.up * 100.0f);
        rb.AddTorque(50.0f);
    }

    public void Success()
    {
        success = true;
        Instantiate(muzzleFlash, muzzlePointHero.transform.position, muzzlePointHero.transform.rotation);
        Debug.Log("Winner!");
        bang.Play();
        Rigidbody2D rb = evilCactus.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * 1337.0f);
        rb.AddForce(transform.up * 100.0f);
        rb.AddTorque(-50.0f);
    }

    private void ExplodePlayer()
    {
        Instantiate(gunExplode, gun.transform.position, gun.transform.rotation);
        Destroy(gun);
        Rigidbody2D rb = heroCactus.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.right * 1337.0f);
        rb.AddForce(transform.up * 100.0f);
        rb.AddTorque(50.0f);
    }

    private void ShootPlayer()
    {
        bang.Play();
        Instantiate(muzzleFlashEvil, muzzlePointEvil.transform.position, muzzlePointEvil.transform.rotation);
    }
}
