using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Vector2 targetPosition;
	private Transform player;
	private Rigidbody2D rigidbody;
	public float smoothing = 3;
	private BoxCollider2D collider;
	private Animator animator;
	public int lossblood = 10;
	void Start(){
		collider = GetComponent<BoxCollider2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		rigidbody = GetComponent<Rigidbody2D> ();
		targetPosition = transform.position;
		GameManager.Instance.enemyList.Add (this);
		animator = GetComponent<Animator> ();
	}
	void Update(){
		rigidbody.MovePosition (Vector2.Lerp(transform.position,targetPosition,smoothing*Time.deltaTime));
	}
	public void Move(){
		Vector2 offset = player.position - transform.position;
		if (offset.magnitude < 1.1f) {
			//ATTACK
			animator.SetTrigger("Attack");//this attack is animation exchange condition
			player.SendMessage("TakeDamage",lossblood);

		} else {
			float x = 0;
			float y = 0;
			if (Mathf.Abs (offset.y) > Mathf.Abs (offset.x)) {
				if (offset.y < 0) {
					y = -1;
				} else {
					y = 1;
				}
			} else {
				if (offset.x < 0) {
					x = -1;
				} else {
					x = 1;
				}
			
			}
			collider.enabled = false;
			RaycastHit2D hit = Physics2D.Linecast (targetPosition,targetPosition + new Vector2(x,y));
			collider.enabled = true;
			if (hit.transform == null) {
				targetPosition += new Vector2 (x, y);
			} else {
				if (hit.collider.tag == "food" || hit.collider.tag == "soda") {
					targetPosition += new Vector2 (x, y);
				}
			}
		}
	}
}
