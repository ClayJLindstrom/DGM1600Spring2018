using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimScript : MonoBehaviour {
	public float moveSpeed;
	public Transform target, chickenPen;
	public VictimShoot shooter;

	// Use this for initialization
	void Start () {
		chickenPen = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
		shooter = gameObject.transform.Find("Shooter").GetComponent<VictimShoot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			target = other.gameObject.transform;
			transform.LookAt(target);
			transform.Translate(Vector3.back* moveSpeed*Time.deltaTime);
			shooter.fire = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			shooter.fire = false;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Respawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
