using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoots : MonoBehaviour {
	public float shootRate = 2;
	private float timer = 0;
	private ParticleSystem ParticleSystem;
	private LineRenderer lineRenderer;
	private Light light;

	public float attack = 30;
	// Use this for initialization
	void Start () {
		ParticleSystem = GetComponentInChildren<ParticleSystem> ();
	//	llineRenderer = this.lineRenderer;
		lineRenderer = GetComponent<LineRenderer>();
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1 / shootRate) {
			timer = 0;
			Shoot ();
		}
	}
	void Shoot(){
		light.enabled = true;
		ParticleSystem.Play ();
		this.lineRenderer.enabled = true;
		Ray ray = new Ray (transform.position,transform.forward);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			lineRenderer.SetPosition (1, hitInfo.point);
			//判断当前shoot 是否碰撞到enemy
			if(hitInfo.collider.tag == "Enemy"){
				hitInfo.collider.GetComponent<EnemyHealth> ().TakeDamege (attack);
			}
		} else {
			lineRenderer.SetPosition (1,transform.position + transform.forward*100);
		}
		Invoke ("ClearEffect",0.05f);

	}
	void ClearEffect(){ 
		light.enabled = false;
		lineRenderer.enabled = false;
	}
}
