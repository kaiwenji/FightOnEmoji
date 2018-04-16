using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigAnimation : MonoBehaviour {

	Animator pigAni;
	// Use this for initialization
	void Start () {
		pigAni = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot() {
		pigAni.SetTrigger ("Shoot");
	}

	public void OnFire() {
		pigAni.SetTrigger ("Fire");
	}
}
