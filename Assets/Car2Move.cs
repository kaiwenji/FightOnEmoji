using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Move : MonoBehaviour {

	public GameObject prefab;
	public float interval=3;
	public Vector2 velocity = Vector2.up;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnNext", 0, interval);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnNext(){
		GameObject go = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
		go.GetComponent<Rigidbody2D> ().velocity = velocity;
	}
}
