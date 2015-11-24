using UnityEngine;
using System.Collections;

public class RotatingFloor : MonoBehaviour {
    public float angularVelocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, angularVelocity * Time.deltaTime);
	}
}
