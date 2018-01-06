using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class route3 : MonoBehaviour {
	public static Transform[] pos;
	void Awake(){
		pos = new Transform[transform.childCount];
		for (int i = 0; i < pos.Length; i++) {
			pos [i] = transform.GetChild (i);
		}
	}
}
