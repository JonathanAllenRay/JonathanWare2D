using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour {

    public Rigidbody2D mainCup;
    public Rigidbody2D sideCup1;
    public Rigidbody2D sideCup2;

    private bool canPick = false;
    private bool success = false;

    public float time;
    private bool ended = false;
    public GameObject textTimer;
    public float timeScaleMod;

    public float force;

    // Use this for initialization
    void Start () {
        Invoke("Shuffle", 1.75f);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Outta Time";
            if (!ended)
            {
                StartCoroutine(Result());
            }
            ended = true;
        }
        else
        {
            int roundedSeconds = (int)time;
            textTimer.GetComponent<UnityEngine.UI.Text>().text = "Time Left: " + roundedSeconds;
        }
    }

    void Shuffle()
    {
        
        Vector2 temp = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        Vector2 temp2 = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        Vector2 temp3 = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        mainCup.AddForce(temp * force);
        sideCup1.AddForce(temp2 * force);
        sideCup2.AddForce(temp3 * force);
        Invoke("Freeze", 2.0f);
    }

    void Freeze()
    {
        mainCup.bodyType = RigidbodyType2D.Static;
        sideCup1.bodyType = RigidbodyType2D.Static;
        sideCup2.bodyType = RigidbodyType2D.Static;
        canPick = true;
    }

    public bool CanPick()
    {
        return canPick;
    }

    public void Success()
    {
        success = true;
    }

    IEnumerator Result()
    {
        if (success)
        {
            LevelSetVars.WonGame();
        }
        else
        {
            LevelSetVars.LostLife();
        }
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/LevelSets/Level1TapGames");
    }

    public void Picked()
    {
        canPick = false;
    }
}
