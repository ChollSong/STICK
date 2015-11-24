using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	//X max maybe 13 and Y max maybe 12.75 na bang bang !
	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;
    //get music clips to play;
    public AudioClip[] musics;
    //check if music is playing
    bool musicPlaying=false;
   
  

    private AudioSource[] jukebox;

	private GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        //Change to be the name of object that our hero use !
        setMusic();
	}
	void LateUpdate(){
        if (target != null)
        {
            transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, xMin, xMax), Mathf.Clamp(target.transform.position.y, yMin, yMax), transform.position.z);
        }
        else
        {
            findAndReattach();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!musicPlaying)
        {
            playRandom();
        }

        musicPlaying = checkMusicPlaying();
	}

    private void findAndReattach()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void setMusic()
    {
        jukebox = new AudioSource[musics.Length];
        for(int i = 0; i < jukebox.Length; i++)
        {
            jukebox[i] = gameObject.AddComponent<AudioSource>();
            jukebox[i].clip = musics[i];
            jukebox[i].volume = 0.2f;
        }
    }

    private void playRandom()
    {
        int i = (int)Random.Range(0.0f, jukebox.Length-1.01f);
        jukebox[i].Play();
        musicPlaying = true;
    }

    private bool checkMusicPlaying()
    { bool musicPlaying = false;
        foreach(AudioSource a in jukebox)
        {
            if (a.isPlaying)
            {
                musicPlaying = true;
                break;
            }
        }
        return musicPlaying;
    }

}
