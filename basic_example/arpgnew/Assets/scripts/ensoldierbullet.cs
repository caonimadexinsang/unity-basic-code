using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ensoldierbullet : MonoBehaviour {
	private GameObject OBJ;
	public float bulletspeed = 50;
	//public int damage = 5;
	// Use this for initialization
	void Start () {

	}
	//it's very important to let bullet have a script!!!!!!!!!!!!!!!!!!!!!!!!!
	// Update is called once per frame
	void Update () {
		if (OBJ == null) {
			Destroy (this.gameObject);
		} else {
			transform.Translate ((OBJ.transform.position - transform.position).normalized * Time.deltaTime * bulletspeed);
			Vector3 dir = transform.position - OBJ.transform.position;
			if (dir.magnitude < 10f) {
				//Debug.Log("soldierbullet10f");
				Destroy (this.gameObject);
			}
		}
	}
	public void Attack(GameObject _obj){
		OBJ = _obj;
	}
}
