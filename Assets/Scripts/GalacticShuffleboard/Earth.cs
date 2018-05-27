using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

    public GalacticeShuffleboardManager gsm;
    public Rigidbody2D earthRigidBody;
    public bool onTarget = false;

    private bool swept = false;
	
	// Update is called once per frame
	void Update () {
        Vector2 temp = SwipeManager.Instance.GetSwipeVector();
        if (temp != Vector2.zero && !swept)
        {
            swept = true;
            earthRigidBody.AddForce(temp * SwipeManager.Instance.GetForce());
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        gsm.SetSuccess();
    }
}

