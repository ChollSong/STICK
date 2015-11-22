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
            if (!pS.hasMaxHealth())
            {
                pS.heal(healPoints);
                Destroy(gameObject);
            }
           
        }
    }
}
