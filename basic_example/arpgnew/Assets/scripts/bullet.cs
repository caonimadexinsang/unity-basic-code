using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	private GameObject OBJ;
	public float speed = 50;
	//public int damage = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OBJ == null) {
			Destroy (this.gameObject);
		} else {
			this.transform.LookAt (OBJ.transform.position);
			this.transform.Translate (Vector3.forward*Time.deltaTime*speed);
			Vector3 dir = OBJ.transform.position - this.transform.position;
			if (dir.magnitude < 5f) {
				Debug.Log("crystalbullet5f");
				Destroy (this.gameObject);
			}
		}
	}
	public void Attack(GameObject obj){
		//this.transform.LookAt (obj.transform.position);
		OBJ = obj;
	}
}
