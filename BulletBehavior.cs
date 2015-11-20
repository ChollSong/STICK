using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    private float lifetime;
    private int damagePerBullet = 10;
    // Use this for initialization
    void Start()
    {
        lifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        move();
        if (lifetime > 3)
        {
            Destroy(gameObject);
        }

        lifetime += Time.deltaTime;
    }

    void move()
    {
        transform.Translate(Vector2.right * 20 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player")) {
            PlayerScript pS = (PlayerScript)coll.gameObject.GetComponent(typeof(PlayerScript));
            pS.damage(damagePerBullet);
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            //damage the player.
        }
        Destroy(gameObject);

    }

}


