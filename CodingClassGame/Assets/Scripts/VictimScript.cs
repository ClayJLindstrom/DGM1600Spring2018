using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimScript : MonoBehaviour {
	public float moveSpeed, errorRoom, turnSpeed;
	public Transform target, chickenPen;
	public VictimShoot shooter;

	// Use this for initialization
	void Start () {
		chickenPen = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
		shooter = gameObject.transform.Find("Shooter").GetComponent<VictimShoot>();
		//Destroy(gameObject, 40);
		errorRoom = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			float forwardAngle = Vector3.Angle(transform.forward, target.position - transform.position);
			/*if(transform.rotation.eulerAngles.x + 7 > 14){
				transform.Rotate(Vector3.right * moveSpeed * Time.deltaTime);
			}
			if(transform.rotation.eulerAngles.z + 7 > 14){
				transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
			}*/
			if(forwardAngle > errorRoom){
				transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
			}
			else{
				if(Vector3.Distance(target.position, transform.position) > 14){
					transform.Translate(Vector3.back* moveSpeed*Time.deltaTime);
				}
				if(target.gameObject.tag == "Player"){shooter.fire = true;}
			}
			//transform.LookAt(target);
		}
		else{shooter.fire = false; Wander();}
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){
			target = other.gameObject.transform;
		}
		else if(other.gameObject.tag == "BlueDice"){
			target = other.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "BlueDice"){
			shooter.fire = false;
			target = null;
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Respawn"){
			shooter.enabled = false;
			gameObject.tag = "Untagged";
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
			GameObject.Find("Canvas").GetComponent<ScoreManager>().AddPoints(1);
		}
		else if(other.gameObject.tag == "BadRespawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
		else if(other.gameObject.tag == "BlueDice"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
			GameObject.Find("Canvas").GetComponent<ScoreManager>().AddPoints(-2f);
		}
	}


	void Wander(){
		transform.Translate(Vector3.forward * moveSpeed * 0.5f * Time.deltaTime);
		int randomNum = Random.Range(0,360);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		Debug.DrawRay(transform.position, fwd, Color.red);

		if(Physics.Raycast(transform.position, fwd, out hit, 3)){
			if(hit.collider.tag == "Wall"){
				transform.Rotate(0, randomNum, 0);
			}
		}
	}
}
