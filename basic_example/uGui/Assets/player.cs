﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 90;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up*Time.deltaTime*speed);
	}
	public void ChangeSpeed(float speedNew){
		this.speed = speedNew;
	}
}
