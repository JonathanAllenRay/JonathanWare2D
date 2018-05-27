using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCar : MonoBehaviour {

    public CarPassingManager cpm;

    public GameObject bang;

    private Vector2 rightLane;
    private Vector2 leftLane;
    private Vector2 dest;

    public float speed = 10.0f;
    private float changeBonus = 32.0f;

	// Use this for initialization
	void Start () {
        rightLane = transform.position;
        dest = rightLane;
        leftLane = new Vector2(-1.57f, rightLane.y);
	}
	
	// Update is called once per frame
	void Update () {
        bool changedSpeed = false;
        if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Left))
        {
            dest = leftLane;
            speed += changeBonus;
            changedSpeed = true;
        }
        else if (SwipeManager.Instance.SwipingInDir(SwipeDirection.Right))
        {
            dest = rightLane;
            speed += changeBonus;
            changedSpeed = true;
        }
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), dest, speed * Time.deltaTime);
        if (changedSpeed)
        {
            speed -= changeBonus;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cpm.Crashed();
        Instantiate(bang, transform.position, transform.rotation);
        Destroy(collision.transform.gameObject);
        Destroy(gameObject);
    }
}
