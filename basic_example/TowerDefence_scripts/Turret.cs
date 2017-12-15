using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public GameObject bulletPrefab;
	public List<GameObject> enemies = new List<GameObject>();
	public float time = 0;
	public float AttackTime = 1;
	public Transform head;
	public Transform fireposition;
	public int damage = 4;
	// Use this for initialization
	void OnTriggerEnter(Collider col){
		if (col.tag == "enemy") {
			enemies.Add (col.gameObject);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "enemy") {
			enemies.Remove (col.gameObject);
		}
	}
	void Start(){
		time = AttackTime;
	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (enemies.Count > 0 && time > AttackTime) {
			time = 0;
			Attack ();
			enemies [0].GetComponent<enemy> ().TackDamage (damage);
			if (enemies [0] == null) {
				UpgradeEnemy ();
			}
		}
		if (enemies.Count > 0 && enemies [0] != null) {
		//	Transform tran = enemies [0].transform;
			Vector3 targetPosition = enemies [0].transform.position;
			targetPosition.y = head.position.y;
		//	tran.position = targetPosition;
			//Rotation targetrotation = enemies [0].transform.rotation;

		//	tran.rotation.z = head.rotation.z;

			head.LookAt (targetPosition);
		}
	}
	void Attack(){
		if (enemies [0] == null) {
			UpgradeEnemy ();
		}
		if (enemies.Count > 0) {
			GameObject Bulletnew = GameObject.Instantiate (bulletPrefab, fireposition.position, fireposition.rotation);
			Bulletnew.GetComponent<bullet> ().SetTarget (enemies[0].GetComponent<Transform>());
		} else {
			time = AttackTime;
		}
	}
	void UpgradeEnemy(){
		List<int> emptyIndex = new List<int>();
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] == null) {
				emptyIndex.Add (i);
			}
		}
		foreach (int i in emptyIndex) {
			enemies.RemoveAt (emptyIndex[i] - i);
		}
	}
}
