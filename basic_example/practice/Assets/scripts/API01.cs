using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API01 : MonoBehaviour {
	public Transform cube;
	public float speed;
	// Use this for initialization
	void Start () {
		cube.position = new Vector3 (0,0,0);
	}

	// Update is called once per frame
	void Update () {
	//	float x = cube.position.x;
		//float newX = Mathf.MoveTowards (x,10,0.01f);
	//	float newX = Mathf.MoveTowards (x,10,Time.deltaTime*speed);
	//	cube.position = new Vector3(Mathf.PingPong(Time.time*speed,10),0,0);
		//cube.position = new Vector3 (newX,0,0);
		if(Input.GetKeyDown(KeyCode.Space)){
			print ("down");
		}
		if (Input.GetKeyUp (KeyCode.Space))
			print ("up");
		if (Input.GetKey (KeyCode.Space))
			print ("getkey");
	}
}
