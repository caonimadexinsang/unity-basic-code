using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playernew : MonoBehaviour {
	public float force_move = 50;
	public Animator anim;
	private bool isGround = false;
	public float jumpVelocity = 10;
	private bool isWall = false;

	private Transform wallTrans;
	private bool isSlide = false;
	// Update is called once per frame
	void Awake(){
		anim = this.GetComponent<Animator> ();
	}
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		if (isSlide == false) {
			if (h > 0.05f) {
				GetComponent<Rigidbody2D> ().AddForce (Vector2.right * force_move * 4);
			} else if (h < -0.05f) {
				GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * force_move * 4);
			}

			if (h > 0.05f) {
				transform.localScale = new Vector3 (1, 1, 1);
			} else if (h < 0.05f) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}
			Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
			anim.SetFloat ("horizontal", Mathf.Abs (h));

			if (isGround && Input.GetKeyDown (KeyCode.Space)) {
				Vector2 velocity1 = GetComponent<Rigidbody2D> ().velocity;
				velocity1.y = jumpVelocity;
				GetComponent<Rigidbody2D> ().velocity = velocity1;
				if (isWall) {
					GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
				}
			}

			//	Vector2 velocity2 = GetComponent<Rigidbody2D>().velocity;
			anim.SetFloat ("vertical", GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			
		}

		if (isWall == false || isGround == true)
			isSlide = false;
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			isGround = true;
			GetComponent<Rigidbody2D> ().gravityScale = 2;
		}
		if (col.collider.tag == "Wall") {
			isWall = true;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
			//wallTrans.position = this.GetComponent<Collider2D> ().transform.position;
			wallTrans.position = col.transform.position;
		}
		anim.SetBool ("isGround",isGround);
		anim.SetBool ("isWall",isWall);
	}
	public void OnCollisionExit2D(Collision2D col){
		if (col.collider.tag == "Ground") {
			isGround = false;
		}
		if (col.collider.tag == "Wall") {
			isWall = false;
			GetComponent<Rigidbody2D> ().gravityScale = 2;
		}
		anim.SetBool ("isGround",isGround);
		anim.SetBool ("isWall",isWall);
	}

	public void ChangeDir(){
		isSlide = true;
		if (wallTrans.position.x < transform.position.x) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else {
			transform.localScale = new Vector3 (-1,1,1);
		}
	}
}
