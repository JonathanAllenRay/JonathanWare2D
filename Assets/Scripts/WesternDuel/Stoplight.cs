using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoplight : MonoBehaviour {

    public AudioSource beep;
    public GameObject gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StoplightDing()
    {
        beep.Play();
    }

    public void StoplightDingFinal()
    {
        beep.pitch += .2f;
        beep.volume += .3f;
        beep.Play();
        ShootAllowed();
    }

    private void ShootAllowed()
    {
        gameManager.GetComponent<WesternDuelManager>().AllowShoot();
    }
}
