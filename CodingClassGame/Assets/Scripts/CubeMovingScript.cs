using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovingScript : MonoBehaviour {

	//public float transx, transy, transz, rotx, roty, rotz ;

	public Vector3 mover;
	public Quaternion rotate;

	public float moveSpeed, turnSpeed, jumpHeight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var j = Input.GetAxis("Jump") * Time.deltaTime * jumpHeight;
		var y = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

		transform.Translate(0,0,z);
		transform.Translate(0,j,0);
		transform.Rotate(0,y,0);

		/*if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(Vector3.right * moveSpeed *  Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back * moveSpeed *  Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * moveSpeed *  Time.deltaTime);
		}*/
	}
}
