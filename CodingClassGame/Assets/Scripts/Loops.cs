using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {
	public int rootBeer = 99;
	// Use this for initialization
	void Start () {
		/*for(int i = 99; i < 198; i++){
			Debug.Log(i + "little bugs in the code, " + i+ " little bugs! You take one down, patch it around, " + (i+1) + " little bugs in the code!");
		}
		bool isFired = false;
		do{
			Debug.Log("you're fired?");
		}while(isFired);*/

		string[] churro = new string[3];
		churro[0] = "First Churro: YUM!";
		churro[1] = "Second Churro: YUM!";
		churro[2] = "Third Churro: Brother stole it!";

		foreach(string chur in churro){
			Debug.Log(chur);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
