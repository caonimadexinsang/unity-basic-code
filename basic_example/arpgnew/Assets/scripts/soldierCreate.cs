using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierCreate : MonoBehaviour {
	private Coroutine coroutine;
	public float createspace = 30;
	private float firstspace = 2;
	public float insidespace = 3;
	public float space = 15;
	public Transform startpos;
	public Transform enestarpos;
	public GameObject Soldier;
	public GameObject enesoldier;
	// Use this for initialization
	void Start () {
		coroutine = StartCoroutine (InstantiateSoldier());
	}
	IEnumerator InstantiateSoldier(){
		yield return new WaitForSeconds (firstspace);
		while (true) {
			for (int i = 1; i < 10; i++) {
				GameObject enSolider = GameObject.Instantiate (enesoldier,enestarpos.position,Quaternion.identity);
				GameObject _Solider = GameObject.Instantiate (Soldier,startpos.position,Quaternion.identity);
				_Solider.GetComponent<soldier> ().Rout (i%3);//1,2,0
				enSolider.GetComponent<enesoldier>().Rout(i%3);
				//Debug.Log ("enemysoldier was created");
				if (i % 3 == 0) {
					yield return new WaitForSeconds (insidespace);
				}
			}
			yield return new WaitForSeconds (space);
		}
	}
}
