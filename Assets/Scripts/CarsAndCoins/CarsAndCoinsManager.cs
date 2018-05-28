using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsAndCoinsManager : MinigameManager {

    private bool success = false;
    public int coins = 3;
    public GameObject coin;

    private void Start()
    {
        for (int i = 0; i < coins; i++)
        {
            Instantiate(coin, new Vector2(Random.Range(-7f, 7f), Random.Range(0f, 3f)), transform.rotation);
        }        
    }

    // Update is called once per frame
    void Update () {
        GameTimeUpdate(success);
	}

    public void GetCoin()
    {
        coins--;
        if (coins <= 0)
        {
            success = true;
        }
    }
}
