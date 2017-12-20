using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyinstantiate : MonoBehaviour {
	public Wave[] waves;
	public Transform start;
	public static int alivecount = 0;
	private Coroutine coroutine;
//	private int count = 0;
	// Use this for initialization
	void Start () {
		coroutine = StartCoroutine (InstantiateEnemy());
	}
	public void Stop(){
		StopCoroutine (coroutine);
	}
	IEnumerator InstantiateEnemy(){
		//count = 
		foreach(Wave wave in waves){
			for (int i = 0; i < wave.count; i++) {
				GameObject.Instantiate (wave.enemyPrefab,start.position,Quaternion.identity);
				alivecount++;
				if(i != wave.count - 1)
				yield return new WaitForSeconds (wave.speed);
			}
			while (alivecount != 0)
				yield return 0;
			yield return new WaitForSeconds (wave.speed);
		}
		while (alivecount > 0) {
			yield return 0;
		}
		GamaMananer.Instance.Win();
	}

}
