using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public int winScore;
	public Text text, winText;


	// Use this for initialization
	void Awake () {
		Time.timeScale =1;
	}
	
	// Update is called once per frame
	void Start () {
		winText.GetComponent<Text>().enabled = false;
		text = GetComponent<Text>();
		score = 0;
	}

	void Update(){
		if(score < 0){
			score = 0;
		}
		if(winScore == score){
			print("New Record!");
			wintext.GetComponent<Text>().enabled = false;
			Time.timeScale = 0;
		}
		if(input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene(0);
		}
	}
	public static void AddPoints(int pointsToAdd){
		score += pointsToAdd;
	}
	public static void Reset(){
		score = 0;
	}
}
