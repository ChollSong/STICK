using UnityEngine;
using System.Collections;

public class UiControl : MonoBehaviour {
    public GameObject loadingScreen;
   
	public void ChangeScence(string sceneName){
        loadingScreen.SetActive(true);
        Application.LoadLevel (sceneName);
	}
	public void LoadScence(string loadName){
        loadingScreen.SetActive(true);
        Application.LoadLevel (loadName);
       
        //area that you would want to set the player prefs to load as well as the previous scence

    }

	public void QuitGame(){
	//	Debug.Log ("GAME EXITED");
		Application.Quit();
	}

}