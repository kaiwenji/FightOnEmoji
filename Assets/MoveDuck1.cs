﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuck1 : MonoBehaviour {
	public int velocity = 2;
	public Sprite RightDuck;
	public Sprite LeftDuck;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x > 16.8 && velocity > 0) {
			//transform.rotation = new Quaternion (0, 0, 0, 0);
			transform.GetComponent<SpriteRenderer>().sprite=LeftDuck;
			velocity = -velocity;
		}
		if (transform.position.x < 11.4 && velocity < 0) {
			//transform.rotation = new Quaternion (0, 180, 0, 0);
			transform.GetComponent<SpriteRenderer>().sprite=RightDuck;
			velocity = -velocity;
		}
		transform.Translate (velocity * Time.deltaTime, 0, 0);
	}

}
