using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Vector3[] movePoints;
	private float stayTime = 0;
	private Transform target;
	//private float chaseRadius = 3;
	public void InitEnemy(Vector3[] points,Transform player){
		movePoints = points;
		target = player;
		stayTime = Random.Range (0,10);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (movePoints == null || movePoints.Length == 0) {
			return;
		}
		if (target != null) {
			float targetDis = Vector3.Distance (this.transform.position,target.position);
			if(targetDis <= chaseRadius)
		}*/
	}
}
