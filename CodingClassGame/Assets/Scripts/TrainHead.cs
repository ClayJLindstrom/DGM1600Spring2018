using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHead : MonoBehaviour {
	public float moveSpeed;
	public Transform target, shooter, chickenPen;
	public int damage;

	// Use this for initialization
	void Start () {
		shooter = gameObject.transform.Find("Shooter").GetComponent<Transform>();
		chickenPen = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.name =="Cube"){
			transform.LookAt(target);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		else{Wander();}
	}

	void OnCollisionEnter(Collision other){
		var hit = other.gameObject;
		var health = hit.GetComponent<PlayerHealth>();

		//add damage
		if(health != null){
			//health.TakeDamage(damage);
		}
		if(hit.tag == "BadRespawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
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
}
