using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntsManager : MinigameManager {


    private bool success = false;
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
	}

    public void Stunted()
    {
        success = true;
    }
}
