using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{

    public GameObject gameManager;

    private FindItManager fim;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        fim = gameManager.GetComponent<FindItManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit)
            {
                fim.IsThisIt(hit.transform.gameObject.name);
            }
        }
    }
}
