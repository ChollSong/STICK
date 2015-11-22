using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartpointScript : MonoBehaviour {

    private int lifeLeft = 3;
    private Text lifeCounter;

    // Use this for initialization
    void Start()
    {
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //exit back to main menu after displaying game over.
    private void gameOver()
    {

    }

    private void displayLife()
    {
        lifeCounter.text = "Life: " + lifeLeft;
    }

    private void spawn()
    {
        Instantiate(Resources.Load("Pre-fab/SpawnResidue"), transform.position, transform.rotation);
        Instantiate(Resources.Load("Pre-fab/player"), transform.position, transform.rotation);
    }


    public void respawn()
    {
        if (lifeLeft > 0)
        {
            lifeLeft--;
            spawn();
            displayLife();
        }
        else
        {
            gameOver();
        }

    }

}
