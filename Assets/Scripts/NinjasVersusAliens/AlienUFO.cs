using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienUFO : MonoBehaviour {

    public NinjasVersusAliensManager nvam;

    public GameObject explosion;
    public GameObject altSpawn;
    public float speed;


	// Use this for initialization
	void Start () {
        speed += Random.Range(0.0f, 1.2f);
        if (Random.Range(0, 2) == 0)
        {
            transform.position = new Vector2(altSpawn.transform.position.x, transform.position.y + Random.Range(-2.0f, 0.0f));
            speed = -speed;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-2.0f, 0.0f));
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        nvam.UFODown();
    }
}
