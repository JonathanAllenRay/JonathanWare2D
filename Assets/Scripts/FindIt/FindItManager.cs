using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItManager : MinigameManager {

    private GameObject[] findables;

    public GameObject dummyTransformer;

    private string nameOfObj;

    private int it;

    private bool started = false;

    private bool success = false;


    // Use this for initialization
    void Start () {
        Time.timeScale += timeScaleMod;
        findables = GameObject.FindGameObjectsWithTag("Findable");
        it = Random.Range(0, findables.Length);
        nameOfObj = findables[it].name;
        for (int i = 0; i < findables.Length; i++)
        {
            if (i != it)
            {
                findables[i].SetActive(false);
            }
        }
        Invoke("ShuffleFindables", 1.0f);

	}
	
	// Update is called once per frame
	void Update () {
        GameTimeUpdate(success);
    }

    void ShuffleFindables()
    {
        started = true;
        for (int i = 0; i < 10; i++)
        {
            int j = Random.Range(0, findables.Length);
            int k = Random.Range(0, findables.Length);
            dummyTransformer.transform.position = findables[j].transform.position;
            findables[j].transform.position = findables[k].transform.position;
            findables[k].transform.position = dummyTransformer.transform.position;
        }
        for (int i = 0; i < findables.Length; i++)
        {
            findables[i].transform.eulerAngles = new Vector3(0, 0, Random.Range(-360.0f, 360.0f));
            findables[i].SetActive(true);
        }
        int n = Random.Range(0, findables.Length);
        dummyTransformer.transform.position = findables[n].transform.position;
        findables[n].transform.position = findables[it].transform.position;
        findables[it].transform.position = dummyTransformer.transform.position;
    }

    public void IsThisIt(string name)
    {
        if (name == nameOfObj && !success && !ended && started)
        {
            Debug.Log("Foudn it");
            success = true;
            // Play ding sound
            // Play some dumbass effect
        }
    }
}
