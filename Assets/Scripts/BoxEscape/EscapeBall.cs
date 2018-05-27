using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeBall : MonoBehaviour {

    public BoxEscapeManager bem;

    private bool hasEscaped = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        bem.Escaped();
    }
}
