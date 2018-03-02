using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaegerScript : MonoBehaviour {
	public float moveSpeed;
	public Transform target, shooter;

	// Use this for initialization
	void Start () {
		moveSpeed = 2;
		shooter = gameObject.transform.Find("Shooter").GetComponent<Transform>();
		Destroy(gameObject, 120);
	}
	
	// Update is called once per frame
	void Update () {
		
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
		transform.LookAt(target);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			if(target == null){target = other.gameObject.GetComponent<Transform>();}
			Follow();
		}
		else if(other.gameObject.tag == "RedDice"){
			if(target == null){target = other.gameObject.GetComponent<Transform>();}
			Follow();
		}
		else{Wander();}
	}
}
