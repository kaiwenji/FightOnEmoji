using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour {
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
	void onfire(){
		//GetComponent<SpriteRenderer>().sprite=
	}
}
