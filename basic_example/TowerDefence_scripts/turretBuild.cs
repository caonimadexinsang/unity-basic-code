using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class turretBuild : MonoBehaviour {
	public turret LaserTurret;
	public turret MissileTurret;
	public turret StandardTurret;
	public turret currentTurret;
	private int Money = 320;
	public Text Moneytext;
	public Animator Anima;
	public GameObject UpgradeCanvas;
	public Button buton;
	private bool has = false;
	public MapCube mapcube;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject() == false) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				bool isCollider = Physics.Raycast (ray,out hit,1000,LayerMask.GetMask("MapCube"));
				if (isCollider) {
					 mapcube = hit.collider.GetComponent<MapCube> ();
					if (mapcube.turretGo == null && currentTurret != null) {
						if (Money > 0 && Money >= currentTurret.cost) {
							mapcube.BuildTurret (currentTurret);
							Money = Money - currentTurret.cost;
							Moneytext.text = "$" + Money;
						} else {
							Anima.SetTrigger ("trigg");
						}
					} else if (mapcube.turretGo != null) {
						if (has == false) {
							ShowUpgradeUI (mapcube.transform.position, mapcube.isUpgrade);
							has = true;
						} else {
							HideUpgrade ();
							has = false;
						}
					}
				}
			}
		}
	}
	void ShowUpgradeUI(Vector3 pos,bool isDisableUpgrade){
		UpgradeCanvas.SetActive (true);
		UpgradeCanvas.transform.position = pos;
		buton.interactable = !isDisableUpgrade;
	}
	void HideUpgrade(){
		UpgradeCanvas.SetActive (false);
	}
	public void OnupgradeButtondown(){
		if (mapcube.Up == false) {
			mapcube.UpgradeTurret (currentTurret);
			HideUpgrade ();
		}
	}
	public void OnDestroyButtonDown(){
		Destroy (mapcube.turretGo);
		HideUpgrade ();
	}
	public void isLaserPointOn(bool ison){
		if (ison == true) {
			currentTurret = LaserTurret;
		}
	}
	public void isMissilePointOn(bool ison){
		if (ison == true)
			currentTurret = MissileTurret;
	}
	public void isStandardPiontOn(bool ison){
		if (ison == true) {
			currentTurret = StandardTurret;
		}
	}

}
