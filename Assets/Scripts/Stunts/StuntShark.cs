using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntShark : MonoBehaviour {

    public float speed = 3.0f;
    private bool canSpin = false;
    private bool spun = false;
    private bool landed = false;

    public CameraFollower cam;
    public StuntsManager sm;

    public GameObject explosion;


    // Use this for initialization
    void Start() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }

    // Update is called once per frame
    void Update() {
        if (canSpin && !landed)
        {
            float turnSpeed = Input.acceleration.x;
            transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime * 800f);
        }
        if (transform.eulerAngles.z > 170 && transform.eulerAngles.z < 190 && !landed) 
        {
            spun = true;
        }
        if (landed && (transform.eulerAngles.z < 50f || transform.eulerAngles.z > 310f)) {
            if (spun)
            {
                sm.Stunted();
            }
        }
        else if (landed)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canSpin = true;
        cam.Follow();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "FloorTrigger")
        {
            landed = true;
        }
    }
}
