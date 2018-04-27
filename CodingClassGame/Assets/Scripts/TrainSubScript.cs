using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSubScript : MonoBehaviour {
	public Transform shooter1, shooter2, pointer, chickenPen;
	public Rigidbody bullet;
	private float moveSpeed, timer, fireRate, bulletSpeed;

	// Use this for initialization
	void Start () {
		shooter1 = gameObject.transform.Find("Shooter").GetComponent<Transform>();
		shooter2 = gameObject.transform.Find("Shooter2").GetComponent<Transform>();
		chickenPen = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
		moveSpeed = 50;
		fireRate = 1;
		bulletSpeed = 200;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(pointer);
		if(Vector3.Distance(transform.position, pointer.position) > 15){
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}

		timer -= Time.deltaTime;
		if(timer <= 0){
			timer = fireRate;
			Rigidbody clone = (Rigidbody)Instantiate(bullet, shooter1.position, shooter1.rotation);
			clone.velocity = shooter1.TransformDirection (Vector3.up * bulletSpeed);
			clone = (Rigidbody)Instantiate(bullet, shooter2.position, shooter2.rotation);
			clone.velocity = shooter2.TransformDirection (Vector3.up * bulletSpeed);
		}
		
		if(pointer.gameObject == null){Debug.Log("Head's Gone"); Destroy(gameObject);}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "BadRespawn"){
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
