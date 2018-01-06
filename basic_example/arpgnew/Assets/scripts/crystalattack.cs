using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crystalattack : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject> ();
	public GameObject bullet;
	public GameObject bulletposition;
	private float AttackTime = 1;
	private float time = 0;
	public int EcrysLife = 100;
	public int damage = 10;
	//public int WcrysLife = 100;
	private int allLife;
	private Slider slider;
	private int soldiercount = 0;

	// Use this for initialization
	void Start () {
		allLife = EcrysLife;
		slider = this.gameObject.GetComponentInChildren<Slider> ();
		time = AttackTime;
	}
	void OnTriggerEnter(Collider col){
		if (this.tag == "enemycrystal") {
			if(col.tag == "Player" || col.tag == "wesoldier"){
				soldiercount++;
			enemies.Add (col.gameObject);
				if (soldiercount == 5) {
					soldiercount = 0;
				}
			//col.gameObject.GetComponent<soldier> ().Changepos (soldiercount);
				col.gameObject.GetComponent<soldier> ().Attackobj.Add(this.gameObject);
			}
		}
		if (this.tag == "wemaincrystal") {
			if(col.tag == "enesoldier"){
				soldiercount++;
				enemies.Add (col.gameObject);
				if (soldiercount == 5) {
					soldiercount = 0;
				}
				//col.gameObject.GetComponent<soldier> ().Changepos (soldiercount);
				col.gameObject.GetComponent<enesoldier> ().Attackobj.Add(this.gameObject);
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (this.tag == "enemycrystal") {
			if (col.tag == "Player" || col.tag == "wesoldier") {
				enemies.Remove (col.gameObject);
			}
		}
		if (this.tag == "wemaincrystal") {
			if (col.tag == "enesoldier") {
				enemies.Remove (col.gameObject);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (enemies.Count > 0 && time > AttackTime) {
			if (enemies [0] == null) {//put it on here is very important!!!!!!!
				UpgradeEnemy ();
			}
			time = 0;
			//if里面的判断很重要！！！！！
			if (enemies.Count > 0 && enemies [0] != null) {
				GameObject Bullet = GameObject.Instantiate (bullet, bulletposition.transform.position, Quaternion.identity);
				Bullet.GetComponent<bullet> ().Attack (enemies [0]);
				if (enemies [0].tag == "wesoldier") {
					enemies [0].GetComponent<soldier> ().TackDamage (damage);
				}
				if (enemies [0].tag == "enesoldier") {
					enemies [0].GetComponent<enesoldier> ().TackDamage (damage);
				}
			}

		}
	}
	public void TackDamage(int damage){
		if (EcrysLife > 0) {
			EcrysLife = EcrysLife - damage;
			//注意！！！！！！！！！！！！！！！
			slider.value = (float)EcrysLife / allLife;//(float)(EcrysLife / allLife) is wrong,because the answer is 0
		//	Debug.Log ("EcrysLife" + EcrysLife);
		//	Debug.Log ("allLife" + allLife);
		//	Debug.Log ("比值" + EcrysLife / allLife);
		} else {
			Destroy (this.gameObject);
		}
	}
	void UpgradeEnemy (){
		List<int> EnemyList = new List<int> ();
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] == null) {
				EnemyList.Add (i);
			}
		}
		foreach (int i in EnemyList) {
			//list是delete一个元素之后，remove later things towards
			enemies.RemoveAt (EnemyList[i] - i);
		}
	}
}
