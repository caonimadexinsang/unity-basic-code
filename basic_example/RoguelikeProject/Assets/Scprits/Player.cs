using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//private int posx = 1;
	//private int posy = 1;
	public float smoothing = 1;//速度
	public float restTime = 1;

	public float restTimer = 0;
	private Vector2 targetPos = new Vector2(1,1);
	private Rigidbody2D rigidbody;
	private BoxCollider2D collider;
	private Animator animator;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D> ();
		animator = GetComponent<Animator> ();//when wall be attacked,people will play the attack animation
	}
	
	// Update is called once per frame
	//important!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	void Update () {
		rigidbody.MovePosition (Vector2.Lerp (transform.position, targetPos, smoothing * Time.deltaTime));
		restTimer += Time.deltaTime;
		if (restTimer < restTime)//if the second key down isn't after first keydown beyond 1 second,this keydown will not be dealed with,and code will continue deal with the first keydown
			return;
		//the next codes,every restTime excute once!!!!!!!!!!!!!
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		//一次只能向一个方向移动，水平移动优先，h>0是水平方向有按下
		if (h != 0) {
			v = 0;
		}
		if (h != 0 || v != 0) {
			GameManager.Instance.Reduce (1);
			collider.enabled = false;
			RaycastHit2D hit = Physics2D.Linecast (targetPos,targetPos + new Vector2(h,v));
			collider.enabled = true;
			if (hit.transform == null) {
				targetPos += new Vector2 (h, v);//h,v要么是1，要么是0或者-1
				//restTimer = 0;
			} 
			else {
				switch (hit.collider.tag) {
				case "outwall":
					break;
				case "wall":
					animator.SetTrigger ("Attack");
					hit.collider.SendMessage ("TakeDamage");
					break;
				case "food":
					GameManager.Instance.AddFood (10);
					targetPos += new Vector2 (h, v);
					Destroy (hit.transform.gameObject);
					break;
				case "soda":
					GameManager.Instance.AddFood (20);
					targetPos += new Vector2 (h, v);
					Destroy (hit.transform.gameObject);
					break;
				case "enemy":
					break;
				}
			}
			GameManager.Instance.OnPlayerMove ();
			restTimer = 0;//even the collider test will be 1 second once,if don't,every frame will test once,and the wall will not until attack twice,will be destroyed after one attack
		}
	}
	public void TakeDamage(int lossblood){
		GameManager.Instance.Reduce (lossblood);
		animator.SetTrigger ("Damage");//播放be attacked animation
	}
}
