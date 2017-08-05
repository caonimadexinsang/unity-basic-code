using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//important!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	private static GameManager instance;
	public static GameManager Instance{
		get{ 
			return instance;
		}
	}
	public int level = 2;
	public int food = 100;
	public int soda = 1;
	public List<Enemy> enemyList = new List<Enemy>();
	private bool sleepStep = true;
	private Text foodtext;
	// Use this for initialization
	void Awake () {
		instance = this;
		InitGame ();
	}
	void InitGame(){
			foodtext = GameObject.Find ("foodtext").GetComponent<Text> ();
		UpdateFoodtext (0);
	}
	void UpdateFoodtext(int foodChange){
		if (foodChange == 0)
			foodtext.text = "Food:" + food;
		else {
			string str = "";
			if (foodChange < 0)
				str = foodChange.ToString ();
			else
				str = '+' + foodChange.ToString();
			foodtext.text = str + "Food:" + food;
		}
	}

	public void Reduce(int count){
		food -= count;
		UpdateFoodtext (-count);
	}
	public void AddFood(int count){
		food += count;	
		UpdateFoodtext (count);
	}
	public void OnPlayerMove(){
		if (sleepStep == true) {
			sleepStep = false;
		} else {
			foreach (var enemy in enemyList)
				enemy.Move ();
				sleepStep = true;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
