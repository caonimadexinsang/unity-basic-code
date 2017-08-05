using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public float attack = 5;
	public float attackTime = 1;
	private float timer = 1;
	private EnemyHealth enemyhealth;
	// Use this for initialization
	void Start () {
		timer = attackTime;
		enemyhealth = this.GetComponent<EnemyHealth> ();
	}

	public void OnTriggerStay(Collider col){
		if (col.tag == "Player" && enemyhealth.hp > 0) {
			timer += Time.deltaTime;
			if (timer >= attackTime) {
				timer -= attackTime;
				col.GetComponent<playerhealth> ().TakeDamage (attack);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
