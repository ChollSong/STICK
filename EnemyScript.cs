using UnityEngine;
using System.Collections;

public class EnemyScript : HumanoidScript {
    // Use this for initialization
    public bool isFliped;
    public Transform sightStart, sightEnd;
    public float patrolStart, patrolEnd;
    public LayerMask layerMask;
    //enemy will not pursue after player has left its boundary points
    
    //x coordinates
    private float positionBoundaryStartX, positionBoundaryEndX;
    
    //raycasthit get player.
    private Transform player;
    private bool playerSpotted = false;
    private int iniHealth = 50;
    
    //cooldown for shooting
    private float shootRate = 0.2f;
    private float shootTimer = 0;
    
    //cooldown
    private float ignoreTime = 3;
    private float detectCoolDown = 0;

    // for movement
    private bool rightTravel = true;
    private int patrolSpeed = 4;
 

    //for player
    private RaycastHit2D p;
    private float lastPosition;

	
    new void Start()
    {   
        base.Start();
        if (isFliped)
        {
            flip();
        }
        setHealth(iniHealth);
        setBoundary();
    }

    new void Update()
    {
        checkingSpawnBall();
        raycasting();
        if (!playerSpotted)
        {
            patrol();
            setSpeed(patrolSpeed);
            getAnimator().speed = 0.6f;
        }
        else
        {
            attack();
        }
        base.Update();
    }

    private void setBoundary()
    {
        positionBoundaryStartX = transform.position.x - patrolStart;
        positionBoundaryEndX = patrolEnd + transform.position.x;
    }
    //for seeing and spotting player
    private void raycasting()
    {  
        Debug.DrawLine(sightStart.position,sightEnd.position,Color.green);
        p = Physics2D.Linecast(new Vector2(sightStart.position.x, sightStart.position.y), new Vector2(sightEnd.position.x, sightEnd.position.y), layerMask);
        if (p)
        {   
            playerSpotted = true;
            stop();
            detectCoolDown = 0;
            lastPosition = p.collider.gameObject.transform.position.x;
        }
        else
        {
            detectCoolDown += Time.deltaTime;
        }

        if (detectCoolDown > ignoreTime)
        {
            playerSpotted = false;
            detectCoolDown = 0;
        }
       
    }

    private void patrol()
    {
        if (rightTravel)
        {
            goRight();
            if (transform.position.x >positionBoundaryEndX)
            {
                stop();
                rightTravel = false;
            }
        }
        else
        {
            goLeft();
            if (transform.position.x < positionBoundaryStartX)
            {
                stop();
                rightTravel = true;
            }
        }
    }
    //pursue actions
    private void attack()
    {
        if (lastPosition > transform.position.x)
        {
            turnRight();
        }
        else
        {
            turnLeft();
        }

        if (shootTimer>shootRate)
        {
            shoot();
            shootTimer = 0;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }
    }

    //50 percent chance of spawning health balls on death.
    private void checkingSpawnBall()
    {
        float i;
        if (getHealth() <= 0)
        {
            i = Random.Range(0f, 1f);
            if (0.5f<i)
            {
                Instantiate(Resources.Load("Pre-fab/HealBall"), transform.position, transform.rotation);
            }
            
        }
    }

    private void turnRight()
    {
        if (isFliped)
        {
            transform.eulerAngles = new Vector3(0, 180f, 180f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void turnLeft()
    {
        if (isFliped)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180.0f, 0);
        }
    }
    
    
   
}
