using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSwipe : MonoBehaviour {

    public BossFightSwipeManager bfsm;

    public GameObject explosion;

    public float speed;
    public GameObject flash;
    private int health = 4;

    public GameObject deathEffect;
    //public SwipeBossFightManager sbfm;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<CatFighter>().CatDead();
            bfsm.EndGame();
        }
        else
        {
            collision.transform.gameObject.GetComponent<FireballScript>().Fizzle();
            Debug.Log("Hit");
            health--;
            flash.SetActive(true);
            Invoke("UndoFlash", .1f);
            if (health <= 0)
            {
                MonsterDie();
            }
        }

    }

    void UndoFlash()
    {
        flash.SetActive(false);
    }

    void MonsterDie()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        bfsm.BossDestroyed();
    }
}
