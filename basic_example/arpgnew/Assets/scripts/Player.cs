using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
	private NavMeshAgent navagent;
	// Use this for initialization
	public float speed = 1;
	void Start () {
		navagent = this.GetComponent<NavMeshAgent> ();
		Camera.main.GetComponent<CameraFollow> ().InitCamera (this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			//	if (EventSystem.current.IsPointerOverGameObject () == false) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			bool isCollider = Physics.Raycast (ray,out hit,1000,LayerMask.GetMask("Terrain"));
			Debug.Log (isCollider);
			//transform.Translate (Input.mousePosition);
			navagent.SetDestination (hit.point + new Vector3(0,4,0));//very important!!!!!
			//transform.position = Vector3.Lerp(transform.position,hit.point + new Vector3(0,5,0),Time.deltaTime*speed);
			//this.transform.position = Vector3.Lerp(this.transform.position,hit.point + new Vector3(0,5,0),Time.deltaTime*speed);
			if (isCollider) {
				Debug.Log ("b");
			//	Vector3 pos = Vector3.MoveTowards (this.transform.position,hit.point + new Vector3(0,5,0),Time.deltaTime*speed);
			//	this.transform.position = pos;
			//	this.transform.position = Vector3.Lerp(this.transform.position,hit.point + new Vector3(0,5,0),Time.deltaTime*speed);
			}
		}
		//}
	}
}
