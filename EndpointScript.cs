using UnityEngine;
using System.Collections;

public class EndpointScript : MonoBehaviour {
    public string sceneLink;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
      if (coll.gameObject.tag.Equals("Player"))
        {
            exit();
        }
    }

    private void exit()
    {
        Application.LoadLevel(sceneLink);
    }
}
