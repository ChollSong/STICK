using UnityEngine;
using System.Collections;

//still need to implement color changing when rotating;
public class HumanoidScript : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Transform gun;
    /*
    index 0 for gun
    index 1 for health
    index 2 for damange
    index 3 for gravity change and jumping at different pitch;
    */
    public AudioClip[] soundClip;
    //constants
    int speed = 8;
    int jumpForce = 700;
    private int health=1;
    float groundRadius = 0.5f;
    int gravityVal = 3;
    //various subparts
    Rigidbody2D body;
    Animator anime;
    SpriteRenderer sprite;
    //child class can access
    protected AudioSource[] soundMakers;
    //logic for movements
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
        setAudioSources();    
        body.gravityScale = gravityVal;
    }

    // Update is called once per frame
   public void Update() {
        move();
        setAnimate();
        checkDeath();
        
    }
    //set audiosources;
    private void setAudioSources()
    {
        soundMakers = new AudioSource[soundClip.Length];
        for(int i = 0; i < soundMakers.Length; i++)
        {
            soundMakers[i] = gameObject.AddComponent<AudioSource>();
            soundMakers[i].clip = soundClip[i];
        }

      
    }
    
    // do movements according to logic
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

    //animate the movement
    private void setAnimate() {
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

    //check if has has max health
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

    //get current health
    public int getHealth()
    {
        return health;
    }

    //sets health
    public void setHealth(int h)
    {
        health = h;
    }

    //decrease hp by d points;
    public void damage(int d)
    {
        soundMakers[2].Play();
        health -= d;

    }

    //restore hp by x points
    public void heal(int x) {
        soundMakers[1].Play();
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
            soundMakers[3].pitch = 2f;
            soundMakers[3].volume = 0.2f;
            soundMakers[3].Play();

        }
    }

    //set bool logic for going right
    public void goRight()
    {
        goingRight = true;
        facingRight = true;
    }

    //set bool logic for going left
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
        soundMakers[0].Play();
        Instantiate(Resources.Load("Pre-fab/flash"),gun.position,transform.rotation);
        Instantiate(Resources.Load("Pre-fab/bullet"), gun.position, transform.rotation);
    }

    //flip upside down
    public void flip() {
        //rotation stuff
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

    //send spritecomponent of the player
    public SpriteRenderer getSprite()
    {
        return sprite;
    }

    public void setSpeed(int s)
    {
        speed = s;
    }

    public Animator getAnimator()
    {
        return anime;
    }
   

    enum Orientation: int {
        UPSIDEDOWN=-1, NORMALSIDE=1
    }


}
