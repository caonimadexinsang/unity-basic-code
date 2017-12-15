using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamaMananer : MonoBehaviour {
	public GameObject endUI;
	public Text endMessage;
	public static GamaMananer Instance;
	private enemyinstantiate EnemyIns;
	// Use this for initialization
	void Awake(){
		Instance = this;
		EnemyIns = GetComponent<enemyinstantiate> (); 
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Win(){
		endUI.SetActive (true);
		endMessage.text = "W i n!";
	}
	public void Failed(){
		EnemyIns.Stop ();
		endUI.SetActive (true);
		endMessage.text = "输了";
	}
	public void OnButtonRetry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void OnButtonMeny(){
		SceneManager.LoadScene (0);
	}
}
