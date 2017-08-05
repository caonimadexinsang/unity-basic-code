using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {
	public float force_move = 50;
	public Animator anim;
	private bool isGround = false;
	public float jumpVelocity = 10;
	// Use this for initialization
	void Awake () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		if (h > 0.05f) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.right * force_move);
		} 
		else if (h < -0.05f) {
			GetComponent<Rigidbody2D>().AddForce (-Vector2.right*force_move);
		}
		//修改朝向
		if (h > 0.05f) {
			transform.localScale = new Vector3 (1,1,1);
		} else if (h < 0.05f) {
			transform.localScale = new Vector3 (-1,1,1);
		}

		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		anim.SetFloat ("horizontal",Mathf.Abs(h));

		if (isGround && Input.GetKeyDown (KeyCode.Space)) {
			Vector2 velocity1 = GetComponent<Rigidbody2D>().velocity;
			velocity1.y = jumpVelocity;
			GetComponent<Rigidbody2D>().velocity = velocity1;
		}

	//	Vector2 velocity2 = GetComponent<Rigidbody2D>().velocity;
		anim.SetFloat ("vertical",GetComponent<Rigidbody2D>().velocity.y);
	}
	public void OnCollisionEnter2D(){
		isGround = true;
	}
	public void OnCollisionExit2D(){
		isGround = false;
	}
}
