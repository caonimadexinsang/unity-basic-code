using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateCamera : MonoBehaviour {
	public GameObject warrior;
	public GameObject archer;
	public Transform playerpos;
	private GameObject current;
	public Text yourname;
	private int have = 0;
	public string name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCreate(){
		name = yourname.text;
		transdata.Instance.Name = name;
		SceneManager.LoadScene (2);
		//Debug.Log (name);
	}
	public void ChooseWarrior(){
		if (have != 0) {
			Destroy (current);
		}
		current = GameObject.Instantiate (warrior,playerpos.position,playerpos.rotation);
		have = 1;
		transdata.Instance.have = have;
	}
	public void ChooseArcher(){
		if (have != 0) {
			Destroy (current);
		}
		current = GameObject.Instantiate (archer,playerpos.position,playerpos.rotation);
		have = 2;
		transdata.Instance.have = have;
	}
}
