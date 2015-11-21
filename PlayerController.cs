using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //set of gameObjects that are player
    private GameObject player;
    private GameObject background;
    PlayerScript p;
    //lockedOnPlayer means that there is a 'puppet' being controled by this class
    private bool lockedOnPlayer = false;
    private bool hasNormalColor = true;
    private float cooldownTimer;
    private bool cd=false;
    private float maxCooldownTime = 3;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.FindGameObjectWithTag("background");
        if (player != null) {
            p = (PlayerScript)player.GetComponent(typeof(PlayerScript));
            lockedOnPlayer = true;
        }  
        
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null) {
            //must be in this order so that it will always be normal.
            //will need to modify this code later
            lockedOnPlayer = false;
            if (!hasNormalColor)
            {
                cd = true;
               //will use flipcolor() later
            }
            if (cd)
            {
                cooldownTimer += Time.deltaTime;
            }
            if (cooldownTimer > maxCooldownTime)
            {
                flipColor();
                cooldownTimer = 0;
                cd = false;
            }
           
        }
        else if(player!=null)
        {
            p = (PlayerScript)player.GetComponent(typeof(PlayerScript));
            lockedOnPlayer = true;
        }

//        detectShake();
        
	}

    private void detectShake() {
        if (Input.acceleration.magnitude>14f) {
            p.flip();
        }
        
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
