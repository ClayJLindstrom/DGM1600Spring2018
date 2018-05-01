using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaegerHealth : MonoBehaviour {

	public int currentHealth, maxHealth = 3, points;
	public Transform chickenPen;
	private JaegerScript attackMode;
	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		currentHealth = 3;
		chickenPen = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
		attackMode = GetComponent<JaegerScript>();
		scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		Debug.Log("Made It");
		if(currentHealth <= 0){
			gameObject.tag = "Untagged";
			attackMode.enabled = false;
			currentHealth = 0;
			print("Blue Tank has Died");
			//add points
			scoreManager.AddPoints(1);
			//move wolf to spawn point
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
			//currentHealth = maxHealth;
			//Destroy(gameObject);
		}
	}
}
