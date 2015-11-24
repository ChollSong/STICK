using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    //set of gameObjects that are player
    private GameObject player;
    private GameObject background;
    PlayerScript p;

    //starting point for respawning.
    private GameObject start;
    private StartpointScript startPoint;

    //lockedOnPlayer means that there is a 'puppet' being controled by this class
    private bool lockedOnPlayer = false;
    private bool hasNormalColor = true;
    private float cooldownTimer;
    private float maxCooldownTime = 3;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.FindGameObjectWithTag("background");
        if (player != null) {
            p = (PlayerScript)player.GetComponent(typeof(PlayerScript));
            lockedOnPlayer = true;
        }
        setStartPoint();

    }
	
	// Update is called once per frame
	void Update () {
        if (player == null) {
            //must be in this order so that it will always be normal.
            //will need to modify this code later
            lockedOnPlayer = false;
            findAndReattach();
            
            //for cooldown
            cooldownTimer += Time.deltaTime;
            
            if (cooldownTimer > maxCooldownTime)
            {
                if (!hasNormalColor)
                {
                    flipColor();
                }
                cooldownTimer = 0;
                startPoint.respawn();
            }

        }
        else
        {
            lockedOnPlayer = true;
        }

//        detectShake();
        
	}
    //might remove this part later
    private void detectShake() {
        if (Input.acceleration.magnitude>14f) {
            p.flip();
        }
        
    }
    //find the respawned player and attach the control to it.
    private void findAndReattach()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            p = (PlayerScript)player.GetComponent(typeof(PlayerScript));
        }

    }

    private void setStartPoint()
    {
        start = GameObject.FindGameObjectWithTag("StartPoint");
        startPoint = (StartpointScript)start.GetComponent(typeof(StartpointScript));
    }

    //flip color of the whole thing can also detect whether player still active
    private void flipColor() { 

         if (lockedOnPlayer)
            {
                p.flipPlayerColor();
            }
    
        if (hasNormalColor)
        {
           
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("platform")){
                g.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            background.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            hasNormalColor = false;
        }
        else
        {
       
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("platform"))
            {
                g.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
            }
            background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            hasNormalColor = true;
        }
    }

    public void flip()
    {//will streamline code later
        if (lockedOnPlayer)
        {
            flipColor();
            p.flip();
        }
    }

    public void goLeft() {
        if (lockedOnPlayer) {
            p.goLeft();
        }
    }

    public void goRight() {
        if (lockedOnPlayer)
        {
            p.goRight();
        }
    }

    public void jump() {
        if (lockedOnPlayer)
        {
            p.jump();
        }
    }

    public void shoot() {
        if (lockedOnPlayer)
        {
            p.shoot();
        }
    }

    public void stop()
    {
        if (lockedOnPlayer)
        {
            p.stop();
        }
    }
   
}
