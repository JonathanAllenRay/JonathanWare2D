using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerHero : MonoBehaviour {

    public Animator ani;
    public GameObject corpse;
    public HeadMoomenManager hm;

    private bool dodged = false;

    private bool dodging;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        SwipeDirection sd = SwipeManager.Instance.GetDir();
        if (sd == SwipeDirection.Left && !dodged)
        {
            dodged = true;
            LeanBack();
        }
    }

    void LeanBack()
    {
        ani.SetTrigger("Dodge");
        dodging = true;
        Invoke("ResetDodge", .4f);

    }

    private void ResetDodge()
    {
        Debug.Log("Moved collider back");
        dodging = false;
    }

    public bool IsDodging()
    {
        return dodging;
    }

    public void Mazzagati()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        corpse.GetComponent<SpriteRenderer>().enabled = true;
        hm.Failed();
    }
}
