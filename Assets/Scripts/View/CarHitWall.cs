﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "wall") {
			Destroy (this.gameObject);
		}

	}
	
}
