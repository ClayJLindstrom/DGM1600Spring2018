using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile, player;
	public Transform shootPoint;
	public int bulletSpeed;
	public bool fire, fireSpeed;
	public float bulletCooldown, timer, bulletStock, bulletStockMax;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Rigidbody>();
		shootPoint = GetComponent<Transform>();
		fire = false;
		bulletCooldown = 0.04f;
		timer = 0f;
		bulletStockMax = 75;
		bulletStock = 75;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(Input.GetButtonDown("Fire1")){
			fire = !fire;
		}

		if(bulletStock <= 0){fire = false; timer = bulletCooldown * 25;}
		

		if(fire && timer <= 0){
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);
			clone.velocity = shootPoint.TransformDirection (Vector3.up * bulletSpeed);
			//player.AddForce(shootPoint.forward * 450);
			timer = bulletCooldown;
			bulletStock -= 1;
		}
		else if(!fire){
			if(bulletStock < bulletStockMax){bulletStock += Time.deltaTime * 25;}
		}
	}
}
