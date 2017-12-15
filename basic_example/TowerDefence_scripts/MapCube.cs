using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MapCube : MonoBehaviour {
	public GameObject turretGo;
	private Renderer renderer = new Renderer();
	public GameObject effect;
	private Color itcolor;
	[HideInInspector]
	public bool isUpgrade = false;
	public bool Up = false;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		itcolor = renderer.material.color;
	}

	// Update is called once per frame
	public void BuildTurret(turret _turret){
		isUpgrade = false;
	//	Transform trans = GameObject.GetComponent<Transform> ();
		//trans.position = trans.position + new Vector3 (0,2,0);
		turretGo = GameObject.Instantiate (_turret.turretPrefab,transform.position + new Vector3 (0,2,0),Quaternion.identity);
		GameObject Effect = GameObject.Instantiate (effect,transform.position + new Vector3(0,2,0),Quaternion.identity);
		Destroy (Effect,1);
		//Destroy (turretGo,3);
	}
	public void UpgradeTurret(turret turretprefab){
		Destroy (turretGo);
		//Debug.Log ("22222222222");
		Up = true;
		turretGo = GameObject.Instantiate (turretprefab.turretUpPrefab,transform.position+ new Vector3(0,2,0),Quaternion.identity);
	}
	//public void Destroyy(){
	//	Destroy (turretGo);
	//}
	void OnMouseEnter(){
		if (turretGo == null && EventSystem.current.IsPointerOverGameObject () == false) {
			//unity里面rgb都是0-1的数，把rgb的每个value除以255
			renderer.material.color = new Color(0.447f,0.066f,0.066f);
		}
	}
	void OnMouseExit(){
		renderer.material.color = itcolor;
	}
}
