using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaternion : MonoBehaviour {
	public Transform cube;

	public Transform player;
	public Transform enemy;
	// Use this for initialization
	void Start () {
		///print (cube.eulerAngles);
	//	print (cube.rotation);

		//cube.eulerAngles = new Vector3 (45,45,45);
	//	cube.rotation = Quaternion.Euler(new Vector3(45,45,45));
	//	print (cube.rotation.eulerAngles);
	
	}
	
	// Update is called once per frame
	void Update () {
	//	if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 dir = enemy.position - player.position;
			dir.y = 0;
			Quaternion target = Quaternion.LookRotation (dir);
		player.rotation = Quaternion.Slerp (player.rotation,target,Time.deltaTime);
			//player.rotation = Quaternion.LookRotation (dir);
			print ("ddddd");
	//	}
	}
}
