using UnityEngine;
using System.Collections;

public class FlashScript : MonoBehaviour {
    private float timer;
    
    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 0.04)
        {
            Destroy(gameObject);
        }
    }
}
