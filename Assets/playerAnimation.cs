using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour {

	Animator playerAni;
	// Use this for initialization
	void Start () {
		playerAni = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMeet() {
		playerAni.SetTrigger ("Meet");
	}

	public void OnFire() {
		playerAni.SetTrigger ("Fire");
	}
}
