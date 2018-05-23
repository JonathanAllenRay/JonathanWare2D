using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeBall : MonoBehaviour {


    private bool hasEscaped = false;

    public bool HasEscaped()
    {

        return hasEscaped;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        hasEscaped = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEscaped = true;
    }
}
