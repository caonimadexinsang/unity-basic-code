using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soldier : MonoBehaviour {
	private int rout;
	private Transform[] RoadPoints;
	private float soldierSpeed = 100;
	private int count = 0;
	//public GameObject AttackTower;
	public List<GameObject> Attackobj = new List<GameObject>();
	public GameObject soldierbullet;
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
		if (col.tag == "enesoldier") {
			Attackobj.Add (col.gameObject);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "enesoldier") {
			Attackobj.Remove (col.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (RoadPoints != null && Attackobj.Count == 0) {
				Move ();
			} else {//soldier attack enemy's tower
			if (time > AttackTime && Attackobj.Count > 0) {
				time = 0;
				if (Attackobj [0] == null) {
					UpgradeList ();
				}
				//Debug.Log ("enterrrrrrrrrr");
				if (Attackobj.Count > 0 && Attackobj [0] != null) {
					GameObject bullet = GameObject.Instantiate (soldierbullet, bulletpos.position, Quaternion.identity);

					bullet.gameObject.GetComponent<soldierbullet> ().Attack (Attackobj [0]);
					if (Attackobj [0].tag == "enemycrystal") {
						Attackobj [0].GetComponent<crystalattack> ().TackDamage (damage);
					}
					if (Attackobj [0].tag == "enesoldier") {
						Attackobj [0].GetComponent<enesoldier> ().TackDamage (damage);
					}
				}
			}
			}
	}
	void Move(){ 
			if (count < RoadPoints.Length) {
				transform.Translate ((RoadPoints [count].position - transform.position).normalized * Time.deltaTime * soldierSpeed);
				if (Vector3.Distance (RoadPoints [count].position, transform.position) < 2f) {
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
	void UpgradeList(){
		List<int> index = new List<int> ();
		for (int i = 0; i < Attackobj.Count; i++) {
			if (Attackobj [i] == null) {
				index.Add (i);
			}
		}
		foreach (int i in index) {
			Attackobj.RemoveAt (index[i] - i);
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
