using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "wall") {
			print ("hitwall");
			Destroy (this.gameObject);
		}

	}
	public void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.tag == "wall") {
			print ("hitwall");
			Destroy (this.gameObject);
		}

	}
}
