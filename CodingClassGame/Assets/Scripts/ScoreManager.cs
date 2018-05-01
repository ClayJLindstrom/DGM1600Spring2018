using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static float score;
	public int winScore;
	public Text scoreText, winText;


	// Use this for initialization
	void Awake () {
		Time.timeScale =1;
	}
	
	// Update is called once per frame
	void Start () {
		winText.GetComponent<Text>().enabled = false;
		//scoreText = GetComponent<Text>();
		score = 0;
		winScore = 50;
	}

	void Update(){
		scoreText.text = score.ToString();
		if(score < 0){
			score = 0;
		}
		if(winScore <= score){
			print("New Record!");
			winText.GetComponent<Text>().enabled = true;
			Time.timeScale = 0;
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene(0);
		}
	}
	public void AddPoints(float pointsToAdd){
		score += pointsToAdd;
	}
	public void Reset(){
		score = 0;
	}
}
