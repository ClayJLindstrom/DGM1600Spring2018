using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimScript : MonoBehaviour {
	public float moveSpeed;
	public Transform target, chickenPen;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			Debug.Log("Target Acquired!");
			target = other.gameObject.transform;
			transform.LookAt(target);
			transform.Translate(Vector3.back* moveSpeed*Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Respawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
