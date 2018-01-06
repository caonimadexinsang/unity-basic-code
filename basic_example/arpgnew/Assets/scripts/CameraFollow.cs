using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform target;
	private float speed = 2;
	private Vector3 offsetPos;
	//第三人称视角
	public void InitCamera(Transform _target){
		target = _target;
		offsetPos = this.transform.position - target.position;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}
		this.transform.position = Vector3.Lerp (this.transform.position,target.position + offsetPos,Time.deltaTime*speed);
		//放大视角
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			if (Camera.main.fieldOfView <= 70) {
				Camera.main.fieldOfView += 5;
			}
		}
		//缩小视角
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			if (Camera.main.fieldOfView >= 30) {
				Camera.main.fieldOfView -= 5;
			}
		}
	}
}
