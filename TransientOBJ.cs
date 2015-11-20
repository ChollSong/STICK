using UnityEngine;
using System.Collections;

public class TransientOBJ : MonoBehaviour {
    public float maxTime;
    private float timer;

    // Update is called once per frame
    public void Update () {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {   
            Destroy(gameObject);
        }
    }

    public void setMaxTime(float t)
    {
        maxTime = t;
    }

    public float getTimer()
    {
        return timer;
    }

}
