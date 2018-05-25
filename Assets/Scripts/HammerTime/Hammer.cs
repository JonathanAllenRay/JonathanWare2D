using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    public Rigidbody2D rb;
    private bool moving = false;
    public BoxCollider2D bc;

    private float forceBonus = 3000.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.bodyType != RigidbodyType2D.Dynamic && Input.GetMouseButtonDown(0))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Left))
        {
            rb.AddForce(-transform.right * forceBonus);
        }
        else if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Right))
        {
            rb.AddForce(transform.right * forceBonus);
        }
        SetMoving();
    }

    private void SetMoving()
    {

        if (Mathf.Abs(rb.angularVelocity) > 300.0f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    public bool IsMoving()
    {
        return moving;
    }
}
