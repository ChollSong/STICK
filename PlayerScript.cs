using UnityEngine;
using System.Collections;

//still need to implement color changing when rotating;
public class PlayerScript : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Transform gun;

    int speed = 7;
    int jumpForce = 600;
    int health = 100;
    float groundRadius = 0.5f;
    int gravityVal = 3;
    Rigidbody2D body;
    Animator anime;
    SpriteRenderer sprite;

    bool goingRight = false;
    bool goingLeft = false;
    bool facingRight = true;
    bool grounded = false;
    int rotationState = (int)Orientation.NORMALSIDE;

    // Use this for initialization
    public void Start() {
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        body.gravityScale = gravityVal;
    }

    // Update is called once per frame
   public void Update() {
        move();
        setAnimate();
        checkDeath();
        
    }

    private void move() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //check whether going left or right
        if (goingRight) {
            if ((int)Orientation.NORMALSIDE == rotationState){
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else {
                transform.eulerAngles = new Vector3(0, 180f, 180f);
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
        if (goingLeft) {
            if ((int)Orientation.NORMALSIDE == rotationState)
            {
                transform.eulerAngles = new Vector3(0, 180.0f, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 180f);
            }
           
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }

    private void setAnimate() {
        //don't forget to multiply by upsidedown enum when need to 
        anime.SetFloat("vSpeed", body.velocity.y * rotationState);
        anime.SetBool("runState", (goingRight || goingLeft) && grounded);
        anime.SetBool("grounded", grounded);
    }
    //checks if the death condition has been reached
    private void checkDeath()
    {
        if (health <= 0)
        {
            GameObject g = (GameObject)Instantiate(Resources.Load("Pre-fab/Corpse"), transform.position, transform.rotation);
            g.GetComponent<ParticleSystem>().startColor = sprite.color;
            Destroy(gameObject);
        }
    }

    public bool hasMaxHealth()
    {
        if (health == 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //is damage by enemy;
    public void damage(int d)
    {
        health -= d;

    }

    public void heal(int x) {
        if ((x + health) > 100)
        {
            health = 100;
        }
        else
        {
            health += x;
        }
    }
    //add force to jump
    public void jump()
    {
        if (grounded)
        {
            body.AddForce(Vector2.up * jumpForce*rotationState);

        }
    }

    public void goRight()
    {
        goingRight = true;
        facingRight = true;
    }

    public void goLeft()
    {
        goingLeft = true;
        facingRight = false;
    }
    //stop left and right movement
    public void stop()
    {
        goingRight = false;
        goingLeft = false;
    }
    //spawning bullets
    public void shoot() {
        Instantiate(Resources.Load("Pre-fab/flash"),gun.position,transform.rotation);
        Instantiate(Resources.Load("Pre-fab/bullet"), gun.position, transform.rotation);
    }
    //need to find someway to implement the flip() function for later;
    public void flip() {

        if (rotationState == (int)Orientation.NORMALSIDE) {
            rotationState = (int)Orientation.UPSIDEDOWN;
            if (facingRight) {
                transform.eulerAngles = new Vector3(0, 180f, 180f);
            }
            else{
                transform.eulerAngles = new Vector3(0, 0, 180f);
            }
            
            body.gravityScale = -1*gravityVal;
        }
        else
        {
            body.gravityScale = gravityVal;
            rotationState = (int)Orientation.NORMALSIDE;
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180.0f, 0);
            }
           
        }
    }

   

    enum Orientation: int {
        UPSIDEDOWN=-1, NORMALSIDE=1
    }


}
