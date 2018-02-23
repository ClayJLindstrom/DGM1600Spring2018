using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour {
	public GameObject[] spawnPoints;
	public GameObject chicken;
	public float timer;

	// Use this for initialization
	void Start () {
		//find all of the spawn points
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		//the chickens that are going to be spawning are my victims
		chicken = (GameObject)Resources.Load("Victim", typeof(GameObject));
		timer = 0;
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 5){Spawn(); timer = 0;}
	}

	void Spawn(){
		//random number from a range to designate a spawn point.
		int spawn = Random.Range(0, spawnPoints.Length);

		GameObject.Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
	}
}
