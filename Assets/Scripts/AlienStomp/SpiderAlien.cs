using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAlien : MonoBehaviour {


    public AlienStompManager asm;

    public GameObject squash;
    public GameObject altSpawn;
    public float speed;


    // Use this for initialization
    void Start()
    {
        speed += Random.Range(0.0f, 4.0f);
        if (Random.Range(0, 2) == 0)
        {
            transform.position = new Vector2(altSpawn.transform.position.x, transform.position.y);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed = -speed;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Barrier")
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed = -speed;
        }
        else
        {
            Instantiate(squash, transform.position, transform.rotation);
            asm.AlienSmashed();
            Destroy(gameObject);
        }
    }
}
