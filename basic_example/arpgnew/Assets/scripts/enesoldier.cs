using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enesoldier : MonoBehaviour {
	private int rout;
	private Transform[] RoadPoints;
	private float soldierSpeed = 100;
	private int count = 0;
	public List<GameObject> Attackobj = new List<GameObject> ();
	//public GameObject[] Attackobj;
	public GameObject ensoldierbullet;
	public Transform bulletpos;
	public float time;
	public float AttackTime = 1;
	public int soldierLife = 50;
	private int damage = 10;
	private int alllife;
	private Slider lifeslider;
	private float changespeed = 30;
	//public int damage = 30;
	// Use this for initialization
	void Start () {
		time = AttackTime;
		lifeslider = this.GetComponentInChildren<Slider> ();
		alllife = soldierLife;
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "wesoldier") {
			Attackobj.Add (col.gameObject);
			Debug.Log ("enemy's col tag" + col.tag);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "wesoldier") {
			Attackobj.Remove (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (RoadPoints != null && Attackobj.Count == 0) {
			Debug.Log ("Attackobj's length" + Attackobj.Count);
			Move ();
		} else {//soldier attack enemy's tower
			if (time > AttackTime && Attackobj.Count > 0) {
				time = 0;
				if (Attackobj [0] == null) {
					UpgradeEnmey ();
				}
				if (Attackobj.Count > 0 && Attackobj [0] != null) {
					//Debug.Log ("enterrrrrrrrrr");
					GameObject bullet = GameObject.Instantiate (ensoldierbullet, bulletpos.position, Quaternion.identity);
					bullet.gameObject.GetComponent<ensoldierbullet> ().Attack (Attackobj [0]);
					if (Attackobj [0].tag == "wemaincrystal") {
						Attackobj [0].GetComponent<crystalattack> ().TackDamage (damage);
					}
					if (Attackobj [0].tag == "wesoldier") {
						Attackobj [0].GetComponent<soldier> ().TackDamage (damage);
					}
				}
			}
		}
	}
	void Move(){ 
		Debug.Log ("enemy move");
		if (count < RoadPoints.Length) {
			transform.Translate ((RoadPoints [RoadPoints.Length -1 -count].position - transform.position).normalized * Time.deltaTime * soldierSpeed);
			if (Vector3.Distance (RoadPoints [RoadPoints.Length -1 -count].position, transform.position) < 2f) {
				//Debug.Log (count);
				count++;
			}
		}
	}
	public void TackDamage(int damage){
		if (soldierLife > 0) {
			soldierLife = soldierLife - damage;
			lifeslider.value = (float)soldierLife / alllife;
		} else {
			Destroy (this.gameObject);
		}
	}
	void Attack(){
		//GameObject bullet = 
	}
	void UpgradeEnmey(){
		List<int> index = new List<int> ();
		for(int i = 0;i < Attackobj.Count;i++){
			if (Attackobj [i] == null) {
				index.Add (i);
			}
		}
		foreach (int i in index) {
			Attackobj.RemoveAt (index[i] - i);
		}
	}
	public void Rout(int _rout){
		rout = _rout;
		if (rout == 0) {
			RoadPoints = route1.pos;
		} else if (rout == 1) {
			RoadPoints = route2.pos;
		} else {
			RoadPoints = route3.pos;
		}
	}
	/*	public void Changepos(int count){
		if (count != 1) {
			int i = count % 2;
			Vector3 dis = new Vector3 (15*i,0,15*(i%1));
			transform.LookAt (transform.position + dis);
			//transform.Translate (Vector3.forward*);
			transform.position += dis;
		}
	}*/
}
