using UnityEngine;
using System.Collections;

public class HealBall : MonoBehaviour {
    private PlayerScript pS;
    private int healPoints = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            pS = (PlayerScript)coll.gameObject.GetComponent(typeof(PlayerScript));
            pS.damage(healPoints);
            //if (!pS.hasMaxHealth())
            //temp for testing
            if(false)
            {
                pS.heal(healPoints);
                Destroy(gameObject);
            }
            //need to del this part once bug test is over
            Destroy(gameObject);
        }
    }
}
