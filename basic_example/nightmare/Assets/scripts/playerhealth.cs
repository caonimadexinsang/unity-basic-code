using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour {
	public float hp = 100;
	private Animator anim;
	public float smoothing = 5;

	private PlayerMove playermove;
	private SkinnedMeshRenderer bodyRenderer;

	private
	// Use this for initialization
	void Awake () {
		anim = this.GetComponent<Animator> ();
		this.playermove = this.GetComponent<PlayerMove> ();
		//this.bodyRenderer = transform.Find ("Player").renderer as SkinnedMeshRenderer;
	//	this.bodyRenderer = this.GetComponent<Renderer>() as SkinnedMeshRenderer;
//		this.bodyRenderer = GameObject.FindGameObjectWithTag("Player").renderer as SkinnedMeshRenderer;
	}
	public void TakeDamage(float damage){
		if (hp <= 0)
			return;
		this.hp -= damage;
//		this.GetComponent<Renderer> ().material.color = Color.red;
	//	bodyRenderer.material.color = Color.red;
		if (this.hp <= 0) {
			anim.SetBool ("Dead",true);
			Dead ();
		}
	}
	// Update is called once per frame
	void Update () {
//		bodyRenderer.material.color = Color.Lerp (bodyRenderer.material.color,Color.white,smoothing*Time.deltaTime);
		if (Input.GetMouseButtonDown(0)) {
			TakeDamage (30);
		}
	}
	void Dead(){
		this.playermove.enabled = false;
	}
}
