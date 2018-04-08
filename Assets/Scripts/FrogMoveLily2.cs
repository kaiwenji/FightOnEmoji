using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoveLily2 : MonoBehaviour {
	Rigidbody2D GetR;
	public int velocity=-1;

	// Use this for initialization
	void Start () {
		GetR = transform.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x>8.62 && velocity > 0) {
			velocity = -velocity;
		}
		if (transform.position.x< -15.32 && velocity < 0) {
			velocity = -velocity;
		}
		transform.Translate (velocity * Time.deltaTime,0, 0);
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.name == "frog") {
			if (velocity < 0)
				velocity = -3;
			else {
				velocity =  3;
			}
			other.transform.parent = transform;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (velocity < 0)
			velocity = -1;
		else {
			velocity = 1;
		}
		other.transform.parent = null;

	}
}
