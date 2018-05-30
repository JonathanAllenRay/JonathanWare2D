using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAndGoRunner : MonoBehaviour {

    public Animator ani;

    public float speed = 3.0f;

    public GameObject explosion;

    public StopAndGoManager sagm;

    private bool localSuccess = false;

	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButton(0))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            ani.speed = 1f;
            if (sagm.GetColor() == LightColor.Red && localSuccess == false)
            {
                Detonate();
            }
        }
        else
        {
            ani.speed = 0f;
        }
        if (!localSuccess && sagm.GetTime() < 0f)
        {
            Detonate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sagm.MadeIt();
        localSuccess = true;
    }

    public void Detonate()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
