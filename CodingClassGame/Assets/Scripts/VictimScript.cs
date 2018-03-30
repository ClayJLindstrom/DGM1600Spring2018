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
		Destroy(gameObject, 120);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			target = other.gameObject.transform;
		}
		else if(other.gameObject.tag == "BlueDice"){
			target = other.gameObject.transform;
		}
		if(target != null){
			float forwardAngle = Vector3.Angle(transform.forward, target.position - transform.position);
			if(transform.rotation.eulerAngles.x + 7 > 14){
				transform.Rotate(Vector3.right * moveSpeed * Time.deltaTime);
			}
			if(transform.rotation.eulerAngles.z + 7 > 14){
				transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
			}
			if(forwardAngle > 10){
				transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime);
			}
			else{
				//transform.Translate(Vector3.back* moveSpeed*Time.deltaTime);
				shooter.fire = true;
			}
			//transform.LookAt(target);
		}
		else{shooter.fire = false;}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "BlueDice"){
			shooter.fire = false;
			target = null;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Respawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
