using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	private float startTime;
	public int Damage = 5;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.1f);
	}

	// Update is called once per frame
//	void Update () {
//		if(Time.time - startTime > 0.1)
//		{
//			Destroy(gameObject);
//		}
//	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("we hit: " + other.tag);
		//if hit chicken
		if (other.tag == "chick" || other.tag == "chick_square") {
			//cook the chicken
			other.gameObject.GetComponent<chicken> ().OnFire ();
		} else if (other.tag == "sheep") {
			//cook the sheep
			other.gameObject.GetComponent<sheep> ().OnFire ();
		} else if (other.tag == "pig") {
			other.gameObject.GetComponent<pig> ().OnFire ();
		} else if (other.tag == "cow") {
			other.gameObject.GetComponent<cow> ().OnFire ();
		} else if (other.tag == "duck") {
			
		} else {
			Debug.Log ("we don't hit any animal");
		}

	}
}
