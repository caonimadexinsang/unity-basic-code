using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {
	private NavMeshAgent agent;
	private Transform player;
	private Animator anim;
	// Use this for initialization
	void Awake () {
		agent = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
	}
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.position) < 1.4f) {
			agent.isStopped = true;
			anim.SetBool ("Move",false);
		} else {
			agent.SetDestination (player.position);
			anim.SetBool("Move",true);
		}
	}
}
