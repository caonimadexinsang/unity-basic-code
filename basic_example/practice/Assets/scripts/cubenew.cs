using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubenew : MonoBehaviour {
	public Transform cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (Input.GetAxis("Horizontal"));
		//cube.Translate (Vector3.right*Time.deltaTime*Input.GetAxis("Horizontal"));
		cube.Translate(Vector3.right*Time.deltaTime*Input.GetAxisRaw("Horizontal"));
		if (Input.anyKeyDown)
			print ("any key down");
		print (Input.mousePosition);
	}
}
