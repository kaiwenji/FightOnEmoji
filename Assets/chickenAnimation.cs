using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenAnimation : MonoBehaviour {

	Animator chickenAni;
	// Use this for initialization
	void Start () {
		chickenAni = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnFire() {
		chickenAni.SetTrigger ("Fire");
	}
}
