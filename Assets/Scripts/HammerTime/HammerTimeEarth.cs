using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTimeEarth : MonoBehaviour {

    public HammerTimeManager htm;

    public void EarthDie()
    {
        htm.EarthDestroyed();
    }

}
