using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("we hit: " + other.tag);
		//if hit chicken
		if (other.tag == "chick") {
			//cook the chicken
			other.gameObject.GetComponent<chicken> ().OnFire ();
		} else if (other.tag == "sheep") {
			//cook the sheep
			other.gameObject.GetComponent<sheep> ().OnFire ();
		} else if (other.tag == "Player") {
			other.gameObject.GetComponent<MultiHamaJump> ().PlayerOnFire ();
			
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
