using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootingMan : MonoBehaviour {

    public TapBossFightManager tbm;

    public GameObject shootingArm;

    public GameObject shotPoint;

    public GameObject bullets;

    public bool dead = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !dead)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(shootingArm.transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if ((angle >= 0.0 && angle <= 90.0) || (angle <= 0.0 && angle >= -90.0))
            {
                shootingArm.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            GameObject newBullet = Instantiate(bullets, shotPoint.transform.position, shotPoint.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 300.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tbm.YouDied();
        shootingArm.transform.eulerAngles = new Vector3(0.0f, 0.0f, -45.0f);
        dead = true;
    }

}



//See also: https://answers.unity.com/questions/633316/how-to-make-the-players-gun-point-and-shoot-in-the.html

