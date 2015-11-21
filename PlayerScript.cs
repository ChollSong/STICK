using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : HumanoidScript {
    //components from ui
    GameObject healthbar;
    Image healthbarVisual;
    RectTransform healthbarRect;
    //sprite component from player;
    Color playerBaseColor;
    SpriteRenderer playerSprite;
   //various values
    private int initHealth = 100;
    private float barLength;
    private float minXvalue;
    //private float maxXvalue;
    private float yStorage;
    //use after getting hit
    private bool cd = false;
    private float cooldownTimer = 0;
    private float cooldownMaxTime = 0.5f;
    //use for flickering
    private bool isBright = true;
    private bool isBlack = true;
	// Use this for initialization
	new void Start () {
        base.Start();
        healthbar = GameObject.Find("Healthbar");
        healthbarVisual = healthbar.GetComponent<Image>();
        healthbarRect = healthbar.GetComponent<RectTransform>();
        playerBaseColor = new Color(0, 0, 0, 255);
        playerSprite = getSprite();
        setIniVal();
    }

    private void setIniVal()
    {
        barLength = healthbarRect.rect.width;
        minXvalue = -1 * barLength;
        yStorage = healthbarRect.localPosition.y;
        setHealth(initHealth);
        setHealthBar(initHealth);
        //makes sure that always start bright red
        isBright = false;
        flipHealthbarColor();
    }

    private void setHealthBar(int h)
    {
        float l = (h * barLength / initHealth)+minXvalue;
        healthbarRect.localPosition = new Vector3(l, yStorage, 0);

    }

    private void flipHealthbarColor()
    {
        if (isBright)
        {   
            healthbarVisual.color = new Color(250, 250, 250, 255);
            playerSprite.color = new Color(100, 0, 0, 255);
            isBright = false;
        }
        else
        {
            healthbarVisual.color = new Color(255, 0, 0, 255);
            playerSprite.color = playerBaseColor;
            isBright = true;
        }
    }

    public void flipPlayerColor()
    {
        if (isBlack)
        {
            playerBaseColor = new Color(255, 255, 255, 255);
            isBlack = false;
        }
        else
        {
            playerBaseColor = new Color(0, 0, 0, 255);
            isBlack = true;
        }

        playerSprite.color = playerBaseColor;
    }

    // Update is called once per frame
    new void Update () {
        base.Update();

        if (cd)
        {
            flipHealthbarColor();
            cooldownTimer += Time.deltaTime;
        }
        if(cooldownTimer> cooldownMaxTime)
        {
            cooldownTimer = 0;
            cd = false;
            isBright = false;
            flipHealthbarColor();
        }
	}

    new public void damage(int d)
    {
        if (!cd)
        {
          base.damage(d);
            setHealthBar(getHealth());
        }
        cd = true;
        
    }

    new public void heal(int h)
    {
        base.heal(h);
        setHealthBar(getHealth());
    }

    

   
}
