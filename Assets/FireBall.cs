using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("we hit: " + other.tag);
		//if hit chicken
		if (other.tag == "chick") {
			//cook the chicken
			other.gameObject.GetComponent<chicken> ().cook ();
		} 
		else if (other.tag == "pig") {
			//cook the pig
		} 
		else if (other.tag == "Player") {
			
		}

	}
}
