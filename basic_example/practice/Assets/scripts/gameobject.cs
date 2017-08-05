using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameobject : MonoBehaviour {
	public GameObject prefab;
	// Use this for initialization
	void Start () {
//		new GameObject("cube");
	//	GameObject go = new GameObject("cuC
		GameObject.CreatePrimitive(PrimitiveType.Plane);
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
		go.AddComponent<Rigidbody> ();
	//	go.AddComponent<time> ();

		Debug.Log (go.activeInHierarchy);
		go.SetActive (false);
		Debug.Log (go.activeInHierarchy);
		Debug.Log (go.tag);


		Debug.Log (go.name);
		Debug.Log (go.GetComponent<Transform>());

		Light light = FindObjectOfType<Light> ();
		light.enabled = false;
		Transform[] ts = FindObjectsOfType<Transform> ();
		foreach (Transform t in ts)
			Debug.Log (t.name);

		//GameObject fin = GameObject.Find ("Main Camera");
		//fin.SetActive (false);
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Main Camera");

		gos[0].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
