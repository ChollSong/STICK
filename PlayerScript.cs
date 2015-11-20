using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : HumanoidScript {
    public RectTransform healthTransform;
    private int initHealth = 100;
    private float iniLength;
    private float minXvalue;
    private float maxXvalue;
    private float yValStorage;
	// Use this for initialization
	new void Start () {
        base.Start();
        setHealth(initHealth);
       
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    new void damage(int d)
    {   
        base.damage(d);
        
    }

    new void heal(int h)
    {
        base.heal(h);
       

    }

    private void setHealthBar(int h)
    {
       
    }
}
