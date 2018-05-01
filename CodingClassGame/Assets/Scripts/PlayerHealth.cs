using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public const int maxHealth = 10;
	public int health;

	public Text hp, maxHP, winText;

	// Use this for initialization
	void Start () {
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		hp.text = health.ToString();
		maxHP.text = maxHealth.ToString();

		if(health <= 0){
			health = 0;
			Time.timeScale = 0;
			winText.GetComponent<Text>().enabled = true;
			winText.text = "YOU ARE DEAD!";
		}
	}

	public void TakeDamage(int amount){
		health -= amount;
	}
}
