using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {
	private Transform[] Positions;
	public float speed = 1;
	private int count = 0;
	public int Life;
	private int RealLife;
	public GameObject effect;
	private Slider slide;
	public int Upmoney;

	// Use this for initialization
	void Start () {
		Positions = RoadPoint.positions;
		slide = GetComponentInChildren<Slider> ();
		RealLife = Life;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	void Move(){
		if (count < Positions.Length) {
			transform.Translate ((Positions [count].position - transform.position).normalized * Time.deltaTime * speed);
			if(Vector3.Distance(Positions[count].position,transform.position) < 0.5f)
			count++;
		}
		if (count >= Positions.Length) {
			ReachDestination ();
		}
	}
	void ReachDestination(){
		GamaMananer.Instance.Failed ();
		GameObject.Destroy (this.gameObject);
	}
	void Destroy(){
		GameObject.Destroy (this.gameObject);
		enemyinstantiate.alivecount--;
	}
	public void TackDamage(int damage){
		if (Life > 0) {
			Life = Life - damage;
			slide.value = (float)Life / RealLife;
			Debug.Log (Life);
		} 
		if(Life <= 0){
			Destroy ();
			GameObject _effect = GameObject.Instantiate (effect,transform.position,Quaternion.identity);
			Destroy (_effect,1);
		}
	}
}
