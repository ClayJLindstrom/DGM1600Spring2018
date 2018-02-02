using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shootPoint;
	public int shootSpeed;
	public bool fire;

	// Use this for initialization
	void Start () {
		fire = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			fire = !fire;
		}

		if(fire){
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);
			clone.velocity = shootPoint.TransformDirection (Vector3.up * shootSpeed);
		}
	}
}
