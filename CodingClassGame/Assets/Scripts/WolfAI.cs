using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {

	public Transform player;
	public float speed, alertDist, wanderRadius, wanderTimer, attackDist;
	private Animator state;
	private Vector3 direction;
	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;
	private float timer, distance;

	void OnEnabled (){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		timer = wanderTimer;
	}

	// Use this for initialization
	void Start () {
		state = GetComponent<Animator>();
		distance = Vector3.Distance(player.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		//Alert
		if(distance <= alertDist && distance > attackDist){
			state.SetBool("Wandering",false);
			state.SetBool("Attacking",false);
			state.SetBool("Following",true);
		}
		//attacking
		else if(distance <= alertDist){

			direction = player.position - transform.position;
			direction.y = 0;

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.05f * Time.deltaTime);

			transform.Translate(Vector3.forward*speed*Time.deltaTime);

			state.SetBool("Wandering",false);
			state.SetBool("Attacking",false);
			state.SetBool("Following",true);

			if(direction.magnitude <= attackDist){
				state.SetBool("Attacking",true);
				state.SetBool("Following",false);
			}
		}
		//Wandering
		else if(distance > alertDist){
			timer += Time.deltaTime;

			if(timer >= wanderTimer){
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);
				timer = 0;
			}

			state.SetBool("Wandering",true);
			state.SetBool("Attacking",false);
			state.SetBool("Following",false);
		}
		
	}
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask){
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		UnityEngine.AI.NavMeshHit navHit;

		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}

}
