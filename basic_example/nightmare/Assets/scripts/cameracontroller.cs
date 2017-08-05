using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour {
	public float smoothing = 3;
	private Transform player;
	private Vector3 offsetStation;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		transform.LookAt (player.position);
		offsetStation = transform.position - player.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = player.position + offsetStation;
		transform.position = Vector3.Lerp (transform.position,targetPos,smoothing*Time.deltaTime);
	}
}
