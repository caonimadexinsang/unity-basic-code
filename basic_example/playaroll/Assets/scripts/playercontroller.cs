using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playercontroller : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text CountText;
	public Text winText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		CountText.text = "Count:" + count.ToString ();
		winText.text = "";
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce (movement*speed);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pickups")) {
			other.gameObject.SetActive (false);
			count++;
			CountText.text = "Count:" + count.ToString ();
			if (count >= 12)
				winText.text = "you win!";
		}
	}
}

