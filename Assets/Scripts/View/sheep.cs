using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour {
	public Sprite cooked;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void cook(){

		GetComponent<SpriteRenderer> ().sprite = cooked;
	}
}
