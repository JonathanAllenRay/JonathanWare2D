using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossCup : MonoBehaviour {

    public Rigidbody2D cupRb;
    public SpriteRenderer cupSr;

    public BoxCollider2D bcBottom;
    public BoxCollider2D canSuccess;

    public BoxCollider2D side1;
    public BoxCollider2D side2;

    public CupTossManager ctm;



    private bool thrown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!thrown)
        {
            if (SwipeManager.Instance.GetDir() != SwipeDirection.None)
            {
                thrown = true;
                cupRb.gravityScale = 0.8f;
                cupRb.AddForce(Vector3.Normalize(SwipeManager.Instance.GetSwipeVector())*1400.0f);
                cupRb.AddTorque(Random.Range(-30.0f, 30.0f));
            }
        }
        if (thrown)
        {
            if (transform.localScale.x >= .9f)
            {
                transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "FloorTrigger")
        {
            bcBottom.enabled = true;
        }
        else if (collision.transform.gameObject.tag == "SuccessBox")
        {
            ctm.InTheCan();
        }
        else
        {
            cupSr.sortingOrder = 2;
            side1.enabled = true;
            side2.enabled = true;
            canSuccess.enabled = true;
        }
    }
}
