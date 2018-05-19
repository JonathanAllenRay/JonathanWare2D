using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

    private bool die = false;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            Destroy(gameObject);
        }
    }

    void EndFlash()
    {
        die = true;
    }
}
