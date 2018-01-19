using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovingScript : MonoBehaviour {
	private Vector3 mover;
	private Rigidbody rb3d;

	// Use this for initialization
	void Start () {
		rb3d = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		mover = rb3d.velocity;
		if(Input.GetKey(KeyCode.W)){
			mover.z = 20;
		}
		if(Input.GetKey(KeyCode.A)){
			mover.x = -20;
		}
		if(Input.GetKey(KeyCode.S)){
			mover.z = -20;
		}
		if(Input.GetKey(KeyCode.D)){
			mover.x = 20; 
		}
		if(Input.GetKey(KeyCode.Space)){
			mover.y = 20;
		}
		rb3d.velocity = mover;
	}
}
