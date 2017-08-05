using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour {
	public float speed = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward*speed*Time.deltaTime);
	}
	public void OnTriggerEnter2D(Collider col){
	}
}
