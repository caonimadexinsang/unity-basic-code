﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public int hp = 2;
	public Sprite damageSprite;//be attacked picture
	public void TakeDamage(){
		hp -= 1;
		GetComponent<SpriteRenderer> ().sprite = damageSprite;
		if (hp <= 0) {
			Destroy (this.gameObject);
		}
	}
}
