using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaegerScript : MonoBehaviour {
	public float moveSpeed;
	public Transform target;

	// Use this for initialization
	void Start () {
		moveSpeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Wander(){
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		int randomNum = Random.Range(0,360);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay(transform.position, fwd * 2, Color.red);

		if(Physics.Raycast(transform.position, fwd * 200, out hit, 3)){
			if(hit.collider.gameObject.tag == "Wall"){
				Debug.Log("Working");
				transform.Rotate(0, randomNum, 0);
			}
		}
	}

	void Follow(){
		transform.LookAt(target);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			if(target == null){target = other.gameObject.GetComponent<Transform>();}
			Follow();
		}
		else{Wander();}
	}
}
