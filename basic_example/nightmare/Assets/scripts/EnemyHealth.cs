using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
	public float hp = 100;
	private Animator anim;
	private NavMeshAgent agent;
	private EnemyMove move;
	private CapsuleCollider capsulecollider;
	private EnemyAttack enemyattack;

	// Use this for initialization
	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		move = this.GetComponent<EnemyMove> ();
		capsulecollider = this.GetComponent<CapsuleCollider> ();
		enemyattack = this.GetComponentInChildren<EnemyAttack> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			transform.Translate (Vector3.down*Time.deltaTime*0.5f);
		}	
		if (transform.position.y <= -10)
			Destroy (this.gameObject);
	}
	public void TakeDamege(float damage){
		if (this.hp <= 0)
			return;
		this.hp -= damage;
		if (this.hp <= 0) {
			Dead ();
		}

	}
	void Dead(){
		anim.SetBool ("Dead",true);
		agent.enabled = false;
		move.enabled = false;
		enemyattack.enabled = false;
	}
}
