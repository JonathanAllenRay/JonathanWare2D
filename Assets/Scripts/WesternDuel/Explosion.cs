using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

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

    void CleanupExplosion()
    {
        die = true;
    }
}
