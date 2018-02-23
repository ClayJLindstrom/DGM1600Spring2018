using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimShoot : MonoBehaviour {
	public Rigidbody projectile, player;
	public Transform shootPoint;
	public int bulletSpeed;
	public bool fire, fireSpeed;
	public float bulletCooldown, timer;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Rigidbody>();
		fire = false;
		bulletCooldown = 0.4f;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fire && timer <= 0){
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);
			clone.velocity = shootPoint.TransformDirection (Vector3.up * bulletSpeed);
			//player.AddForce(shootPoint.forward * 450);
			timer = bulletCooldown;
		}
		else if(fire){timer -= Time.deltaTime;}
	}
}
