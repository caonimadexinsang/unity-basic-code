using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float speed = 1;
	private Rigidbody rb;
	private Animator anim;
	private int groundLayerIndex = -1;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		groundLayerIndex = LayerMask.GetMask ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		//control translate
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
	//	transform.Translate (new Vector3(h,0,v)*speed*Time.deltaTime);
		rb = GetComponent<Rigidbody>();
		rb.MovePosition (transform.position + new Vector3(h,0,v)*speed*Time.deltaTime);
		//GetComponent<>().rigidbody.MovePosition(transform.position + new Vector3(h,0,v)*speed*Time.deltaTime);
		//Rigidbody.

		//control rotation
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo, 200, groundLayerIndex)) {
			Vector3 target = hitInfo.point;//target is what mouse is pointing at
			target.y = transform.position.y;
			transform.LookAt (target);
		}

		//control animation
		if (h != 0 || v != 0) {
			anim.SetBool ("Move", true);
		} else {
			anim.SetBool ("Move",false);
		}
	}
}
