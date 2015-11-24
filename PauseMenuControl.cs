using UnityEngine;
using System.Collections;

public class PauseMenuControl : MonoBehaviour {
    private string menulink;
    public GameObject panel;
    private bool isClicked = false;
	// Use this for initialization
	void Start () {
        menulink = "main_menu";
        panel.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pauseGame()
    {
        if (!isClicked)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            isClicked = true;
        }
        else
        {
            isClicked = false;
            resumeGame();
        }
        
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void exit()
    {

        Application.Quit();

    }

    public void Mainmenu()
    {
        Application.LoadLevel(menulink);

    }

}
