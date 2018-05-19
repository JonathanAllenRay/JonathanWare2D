using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

    public Animator ani;
    public bool theCup;

    public GameObject gameManager;
    private ShuffleManager sm;

	// Use this for initialization
	void Start () {
        sm = gameManager.GetComponent<ShuffleManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (sm.CanPick())
        {
            sm.Picked();
            ani.SetTrigger("Reveal");
            if (theCup)
            {
                sm.Success();
            }
        }
    
    }
}
