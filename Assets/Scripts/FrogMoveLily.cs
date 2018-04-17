using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoveLily : MonoBehaviour {
	Rigidbody2D GetR;
	public int velocity=1;
	//public int ConstantVelocity = -1;
	public bool IsFrogOn=false;
	// Use this for initialization
	void Start () {
		GetR = transform.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x< 3.9 && velocity < 0) {
			velocity = -velocity;
		}
		if (transform.position.x> 13.5f && velocity > 0) {
			velocity = -velocity;
		}
		transform.Translate (velocity * Time.deltaTime,0, 0);
		  
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.name == "frog") {
			//IsFrogOn = true;
			other.transform.parent = transform;
			if (velocity < 0)
				velocity = -3;
			else
				velocity = 3;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (velocity > 0)
			velocity = 1;
		else
			velocity = -1;
		other.transform.parent = null;
	
	}
}
