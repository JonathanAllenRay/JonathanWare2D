using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSnowman : MonoBehaviour {

    public MazeDragManager mdm;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "SuccessBox")
        {
            mdm.MadeIt();
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            mdm.Dead();
        }
    }
}
