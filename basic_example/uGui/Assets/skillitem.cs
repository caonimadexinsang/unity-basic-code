using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillitem : MonoBehaviour {
	public float coldTime = 2;
	public KeyCode keycode;
	private float timer = 0;
	private bool isStartTimer = false;
	private Image filledimage;
	// Use this for initialization
	void Start () {
		filledimage = transform.Find ("FilledImage").GetComponent<Image> ();
		//filledimage
	}
	
	// Update is called once per frame
	void Update () {
		if (isStartTimer == true) {
			timer += Time.deltaTime;
			filledimage.fillAmount = (coldTime - timer) / coldTime;
			if (timer >= coldTime) {
				filledimage.fillAmount = 0;
				timer = 0;
				isStartTimer = false;
			}
		}
	}
	public void OnClick(){
		isStartTimer = true;
	}
}
