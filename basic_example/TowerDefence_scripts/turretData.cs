using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class turret  {
	public TurretType type;
	public GameObject turretPrefab;
	public int cost;
	public GameObject turretUpPrefab;
	public int Upcost;
}
public enum TurretType{
	Laser,
	Missile,
	Standard
}
