using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodyposition : MonoBehaviour {
	public Rigidbody playerRgd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	playerRgd.position = playerRgd.transform.position + Vector3.forward * Time.deltaTime;
		playerRgd.MovePosition(playerRgd.transform.position + Vector3.forward*Time.deltaTime);
	}
}
