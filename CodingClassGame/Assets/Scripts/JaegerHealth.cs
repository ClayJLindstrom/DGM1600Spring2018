using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaegerHealth : MonoBehaviour {

	public int currentHealth, maxHealth = 3, points;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			currentHealth = 0;
			print("Blue Tank has Died");
			//add points
			//scoreManager.AddPoints(points);
			//move wolf to spawn point
			transform.position = spawnPoint.position;
			transform.rotation = spawnPoint.rotation;
			currentHealth = maxHealth;
		}
	}
}
