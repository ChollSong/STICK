using UnityEngine;
using System.Collections;

public class FlashScript : TransientOBJ {
   
    void Start()
    {
        setMaxTime(0.04f);
    }
    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
        
    }
}
