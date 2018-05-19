using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {


    public Animator ani;


	// Use this for initialization
	void Start () {
        Invoke("DieBall", 6.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "EnergyBall")
        {
            DieBall();
        }
    }


    private void DieBall()
    {
        ani.SetTrigger("DeadBall");
        Invoke("CleanupEnergy", 0.3f);
    }

    private void CleanupEnergy()
    {
        Destroy(gameObject);
    }
}
