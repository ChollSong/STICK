using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartpointScript : MonoBehaviour {

    private int lifeLeft = 3;
    private Text lifeCounter;
    private float gameoverMaxTime = 3;
    private float gameoverTimer = 0;
    private bool gameoverStarting = false;
    
    // Use this for initialization
    void Start()
    {
        lifeLeft = 3;
        lifeCounter = GameObject.Find("LifeCounter").GetComponent<Text>();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverStarting)
        {
            gameoverTimer += Time.deltaTime;
        }
        if (gameoverMaxTime < gameoverTimer)
        {
            Application.LoadLevel("main_menu");
        }

    }
    
    private void gameOver()
    {
        gameoverStarting = true;

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
