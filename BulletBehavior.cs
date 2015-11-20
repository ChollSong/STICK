using UnityEngine;
using System.Collections;

public class BulletBehavior : TransientOBJ {

    private int damagePerBullet = 10;
    // Use this for initialization
    void Start()
    {
        setMaxTime(3);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        move();
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


