using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickTapObject : MonoBehaviour {
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit)
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }
}
