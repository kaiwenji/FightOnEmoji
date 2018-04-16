using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class randomlyWalk : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public float maxX = -41f;
	public float minX = -52f;
	public float maxY = 25f;
	public float minY = 5f;

	//chicken
	public float chick_maxX = -57f;
	public float chick_minX = -68f;
	public float chick_maxY = 7f;
	public float chick_minY = 1.3f;

	private float tChange = 0f; // force new direction in the first Update
	private float randomX;
	private float randomY;

	void Update () {
		// change to random direction at random intervals
		if (Time.time >= tChange){
			randomX = Random.Range(-4.0f,4.0f); // with float parameters, a random float
			randomY = Random.Range(-4.0f,4.0f); //  between -2.0 and 2.0 is returned
			// set a random interval between 0.5 and 1.5
			Debug.Log(randomX+" "+randomY);
			tChange = Time.time + 1.5f;
		}
		if (transform.CompareTag ("chick_square")) {
			Vector3 v = new Vector3 (randomX, randomY, 0).normalized;

			transform.Translate(v*moveSpeed* Time.deltaTime);
			// if object reached any border, revert the appropriate direction
			if (transform.position.x >= chick_maxX || transform.position.x <= chick_minX) {
				randomX = -randomX;
			}
			if (transform.position.y >= chick_maxY || transform.position.y <= chick_minY) {
				randomY = -randomY;
			}
		}
		Vector3 v1 = new Vector3 (randomX, randomY, 0).normalized;
		transform.Translate(v1*moveSpeed* Time.deltaTime);
		// if object reached any border, revert the appropriate direction
		if (transform.position.x >= maxX || transform.position.x <= minX) {
			randomX = -randomX;
		}
		if (transform.position.y >= maxY || transform.position.y <= minY) {
			randomY = -randomY;
		}

	}




}
