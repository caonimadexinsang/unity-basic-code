using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class createPlayer : MonoBehaviour {
	public Transform startposition;
	private int Have;
	public GameObject warrior;
	public GameObject archer;
//	Vector3 targetPosition;
	//public float movespeed = 10;
	private GameObject current;
	// Use this for initialization
	void Start () {
		Have = transdata.Instance.have;
		if (Have == 1) {
			current = GameObject.Instantiate (warrior, startposition.position, startposition.rotation);
			current.transform.localScale *= 8;

		} else if (Have == 2) {
			current = GameObject.Instantiate (archer,startposition.position,startposition.rotation); 
			current.transform.localScale *= 8;
		}
		current.AddComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
