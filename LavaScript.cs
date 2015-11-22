using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour
{
    int damageForLava = 1000;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            PlayerScript pS = (PlayerScript)coll.gameObject.GetComponent(typeof(PlayerScript));
            pS.damage(damageForLava);
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            
        }
    }
}
