using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {
    //amplitude of how far the platform vibrates about its position
    public float amplitudeX;
    public float amplitudeY;
    //w is angular speed
    public float wX;
    public float wY;

    //theta in degree
    public float thetha;
    public float phi;

    private Vector3 origin;
    private Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        origin = rigidBody.position;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        rigidBody.MovePosition(origin + new Vector3(amplitudeX*Mathf.Cos(wX*Time.time+(thetha/ 180)* Mathf.PI), amplitudeY * Mathf.Sin(wY * Time.time + (phi / 180) * Mathf.PI), 0));
	}
    
}
