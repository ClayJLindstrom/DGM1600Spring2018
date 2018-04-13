using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour {
	public GameObject[] spawnPoints;
	public GameObject chicken, wolf;
	public float timer, timer2;

	// Use this for initialization
	void Start () {
		//find all of the spawn points
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		//the chickens that are going to be spawning are my victims
		chicken = (GameObject)Resources.Load("RedDice", typeof(GameObject));
		wolf = (GameObject)Resources.Load("Victim", typeof(GameObject));
		timer = 0;
		Spawn(chicken);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 2){Spawn(chicken); timer = 0; timer2 += 1;}
		//if(timer2 > 3){Spawn(wolf); timer2 = 0;}
	}

	void Spawn(GameObject theSpawn){
		//random number from a range to designate a spawn point.
		int spawn = Random.Range(0, spawnPoints.Length);

		GameObject.Instantiate(theSpawn, spawnPoints[spawn].transform.position, Quaternion.identity);
	}
}
