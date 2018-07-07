using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCity : MonoBehaviour {

    public CityDefenderManager cdm;
    public GameObject explosionBig;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Destroyed()
    {
        Instantiate(explosionBig, transform.position, transform.rotation);
        Destroy(gameObject);
        cdm.CityDestroyed();
    }
}
