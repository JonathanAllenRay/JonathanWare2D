using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNinja : MonoBehaviour
{

    public GameObject preArm;

    public GameObject throwingArm;

    public GameObject ninjaStar;

    public GameObject throwPoint;

    private bool thrown = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!SwipeManager.Instance.SwipingInDir(SwipeDirection.Left) && SwipeManager.Instance.GetDir() != SwipeDirection.None && !thrown)
        {
            thrown = true;
            preArm.SetActive(false);
            throwingArm.SetActive(true);
            Vector3 pos = Camera.main.WorldToScreenPoint(SwipeManager.Instance.GetDownTouchPosition());
            Vector3 dir = Camera.main.WorldToScreenPoint(SwipeManager.Instance.GetUpTouchPosition()) - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if ((angle >= 0.0 && angle <= 90.0) || (angle <= 0.0 && angle >= -90.0))
            {
                throwingArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            GameObject star = Instantiate(ninjaStar, throwPoint.transform.position, throwPoint.transform.rotation);
            star.GetComponent<Rigidbody2D>().AddForce(SwipeManager.Instance.GetSwipeVector() * SwipeManager.Instance.GetForce() * 2.0f);
            star.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0.0f, 30.0f));
        }
    }
}
