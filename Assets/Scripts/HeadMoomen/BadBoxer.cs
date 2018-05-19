using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBoxer : MonoBehaviour {

    public Animator ani;
    public BoxerHero boxer;

    public GameObject bang;
    public GameObject bangPoint;

	// Use this for initialization
	void Start () {
        Invoke("ThrowPunch", Random.Range(.8f, 1.8f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ThrowPunch()
    {
        ani.SetTrigger("PunchBad");
        Invoke("PunchInAction", 0.5f);
    }

    void PunchInAction()
    {
        if (!boxer.IsDodging())
        {
            Knockout();
        }
    }

    private void Knockout()
    {
        Debug.Log("KO");
        Instantiate(bang, bangPoint.transform.position, transform.rotation);
        boxer.Mazzagati();

    }
}
