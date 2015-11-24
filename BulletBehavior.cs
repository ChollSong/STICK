using UnityEngine;
using System.Collections;

public class BulletBehavior : TransientOBJ {

    private int damagePerBullet = 10;
    private int bulletSpeed = 25;
    
    // Use this for initialization
    void Start()
    {
        setMaxTime(3);
        //layer 11 is layer of bullets
        Physics2D.IgnoreLayerCollision(11, 11);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        move();
    }

    void move()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player")) {
            PlayerScript pS = (PlayerScript)coll.gameObject.GetComponent(typeof(PlayerScript));
            pS.damage(damagePerBullet);
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            EnemyScript eS = (EnemyScript)coll.gameObject.GetComponent(typeof(HumanoidScript));
            eS.damage(damagePerBullet);
        }
        Destroy(gameObject);

    }

}


