using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {
	public Transform cube;
	public int runCount = 10000;
	// Use this for initialization
	void Start () {
		float time1 = Time.realtimeSinceStartup;
		for (int i = 0; i < runCount; i++)
			Method1();
		float time2 = Time.realtimeSinceStartup;
		Debug.Log (time2 - time1);
		float time3 = Time.realtimeSinceStartup;
		for (int i = 0; i < runCount; i++)
			Method2();
		float time4 = Time.realtimeSinceStartup;
		Debug.Log (time4 - time3);
		
	}
	
	// Update is called once per frame
	void Update () {
		cube.Translate (Vector3.forward*Time.deltaTime);
		Debug.Log ("Time.deltaTime:"+Time.deltaTime);
		Time.timeScale = 3f;

	}
	void Method1(){
		int i = 1 + 2;
	}
	void Method2(){
		int j = 1 * 2;
	}
}
