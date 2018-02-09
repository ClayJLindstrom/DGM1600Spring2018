using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shootPoint;
	public int bulletSpeed;
	public bool fire, fireSpeed;
	public float bulletCooldown, timer;

	// Use this for initialization
	void Start () {
		fire = false;
		bulletCooldown = 0.04f;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			fire = !fire;
		}
		

		if(fire && timer <= 0){
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);
			clone.velocity = shootPoint.TransformDirection (Vector3.up * bulletSpeed);
			timer = bulletCooldown;
		}
		else if(fire){timer -= Time.deltaTime;}
	}
}
