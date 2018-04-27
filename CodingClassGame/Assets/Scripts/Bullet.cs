using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int damage = 1;
	public int time = 1;

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerHealth>().health -= 1;
		}
		else if(other.gameObject.tag == "RedDice" && other.isTrigger == false){
			other.gameObject.transform.position = other.gameObject.GetComponent<VictimScript>().chickenPen.position;
			other.gameObject.transform.rotation = other.gameObject.GetComponent<VictimScript>().chickenPen.rotation;
			GameObject.Find("Canvas").GetComponent<ScoreManager>().AddPoints(1);

		}
		else if(other.gameObject.tag == "BlueDice" && other.isTrigger == false){
			other.gameObject.GetComponent<JaegerHealth>().TakeDamage(damage);
			GameObject.Find("Canvas").GetComponent<ScoreManager>().AddPoints(1);
		}
	}

	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
