using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vec2 : MonoBehaviour {
	public Transform cube;
	// Use this for initialization
	void Start () {
	/*	print (Vector2.down);
		print (Vector2.up);
		print(Vector2.left);
		print (Vector2.right);
		print (Vector2.one);
		print (Vector2.zero);

		Vector2 a = new Vector2 (2,2);
		Vector2 b = new Vector2 (3,4);
		print (a.magnitude);
		print (a.sqrMagnitude);
		print (b.magnitude);
		print (b.sqrMagnitude);

		print (a.normalized);
		print (b.normalized);

		a.Normalize();
		print (a.x + "," + a.y);
		print (a[0] + "," + a[1]);*/


	/*	Vector2 a = new Vector2 (2,2);
		Vector2 b = new Vector2 (3,4);
		Vector2 c = new Vector2 (3,0);

		print (Vector2.Angle (a, b));
		print (Vector2.ClampMagnitude(c,2));
		print (Vector2.Distance(b,c));

		print (Vector2.Lerp(a,b,0.5f));
		print (Vector2.LerpUnclamped(a,b,0.5f));

		print (Vector2.Max(a,b));
		print (Vector2.Min(a,b));*/
		//Random.InitState ((int)System.DateTime.Now.Ticks);

	}
	public Vector2 a = new Vector2 (2,2);
	public Vector2 target = new Vector2 (10,3);
	// Update is called once per frame
	void Update () {
		//a = Vector2.MoveTowards (a,target,Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.Space)) {
			print (Random.Range (4, 100));
			//cube.position = Random.insideUnitCircle * 5;
			cube.position = Random.insideUnitSphere*5;
		}
	}
}
