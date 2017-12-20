using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroll : MonoBehaviour {
	public float mousemove = 20;
	public float Movespeed = 3000;
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float mouse = Input.GetAxis ("Mouse ScrollWheel");
		transform.Translate (new Vector3(h*Movespeed,-mouse*mousemove,v*Movespeed)*Time.deltaTime,Space.World);
	}
}
