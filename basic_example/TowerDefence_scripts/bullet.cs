using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	private Transform target;
	public float speed = 50;
	// Use this for initialization
	void Start () {
		
	}
	public void SetTarget(Transform _target){
		target = _target;
	}
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Destroy (this.gameObject);

		}
		if (target != null) {
			transform.LookAt (target.position);
			transform.Translate (Vector3.forward*speed*Time.deltaTime);
			Vector3 dir = target.position - transform.position;
			if (dir.magnitude < 1.2f) {
				Destroy (this.gameObject);
			}
		}
	}
}
