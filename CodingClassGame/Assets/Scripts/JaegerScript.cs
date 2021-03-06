﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaegerScript : MonoBehaviour {
	public float moveSpeed= 2;
	public Transform target, shooter;

	// Use this for initialization
	void Start () {
		shooter = gameObject.transform.Find("Shooter").GetComponent<Transform>();
		//Destroy(gameObject, 120);
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			/*if(Vector3.Distance(target.position, transform.position) > 10){
				target = null;
			}*/
			Follow();
		}
		else{Wander();}
		
	}

	void Wander(){
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		int randomNum = Random.Range(0,360);
		Vector3 fwd = shooter.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay(shooter.position, fwd, Color.red);

		if(Physics.Raycast(shooter.position, fwd, out hit, 3)){
			if(hit.collider.tag == "Wall"){
				transform.Rotate(0, randomNum, 0);
			}
		}
	}

	void Follow(){
		print(target.position.x.ToString());
		transform.LookAt(target);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			target = other.gameObject.GetComponent<Transform>();
		}
		else if(other.gameObject.tag == "RedDice"){
			if(target == null){target = other.gameObject.GetComponent<Transform>();}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			GameObject.Find("Canvas").GetComponent<ScoreManager>().AddPoints(-1);
			other.gameObject.GetComponent<PlayerHealth>().health -= 1;
			target = null;
			int randomNum = Random.Range(0,360);
			transform.Rotate(0, randomNum, 0);
		}
	}
}
