using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //set of gameObjects that are player
    private GameObject player;
    private GameObject background;
    PlayerScript p;
    private bool lockedOnPlayer = false;
    private bool hasNormalColor = true;
    

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
            lockedOnPlayer =false;
            
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

    private void flipColor()
    {
        if (hasNormalColor)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("platform")){
                g.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            background.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            hasNormalColor = false;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
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
