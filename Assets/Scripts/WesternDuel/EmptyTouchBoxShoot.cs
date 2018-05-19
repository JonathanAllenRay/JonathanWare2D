using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTouchBoxShoot : MonoBehaviour {

    public GameObject gameManager;
    private WesternDuelManager wdm;

	// Use this for initialization
	void Start () {
        wdm = gameManager.GetComponent<WesternDuelManager>();
	}

    void OnMouseDown()
    {
        if (!wdm.IsDead() && wdm.CanShoot() && !wdm.HasSuccess()) 
        {
            wdm.Success();
        }
        else if (!wdm.CanShoot() && !wdm.IsDead())
        {
            wdm.FailureTooEarly();
        }
    }
}
