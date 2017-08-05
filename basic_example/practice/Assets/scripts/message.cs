using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		//target.BroadcastMessage ("Attack",null,SendMessageOptions.DontRequireReceiver);
		//target.SendMessage("Attack",null,SendMessageOptions.DontRequireReceiver);
		//target.SendMessageUpwards("Attack",null,SendMessageOptions.DontRequireReceiver);

		cube1 cube = target.GetComponent<cube1> ();
		Transform t = target.GetComponent<Transform> ();
		Debug.Log ("........................");
		Debug.Log (cube);
		Debug.Log (t);
		Debug.Log ("........................");

		cube1[] cubes = target.GetComponents<cube1>();
		Debug.Log (cubes.Length);
		Debug.Log ("........................");

		cubes = target.GetComponentsInChildren<cube1> ();
		foreach (cube1 c in cubes)
			Debug.Log (c);
		Debug.Log ("........................");
		cubes = target.GetComponentsInParent<cube1> ();
		foreach (cube1 c in cubes)
			Debug.Log (c);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
