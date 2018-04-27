using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	public Collider collider;

	public int levelToLoad;

	public void LoadLevel(){
		SceneManager.LoadScene(levelToLoad);
	}

	public void LevelExit(){
		Application.Quit();
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			LoadLevel();
		}
	}
}
