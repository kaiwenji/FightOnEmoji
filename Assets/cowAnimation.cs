using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowAnimation : MonoBehaviour {

	Animator cowAni;
	// Use this for initialization
	void Start () {
		cowAni = transform.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}
	public void Shoot() {
		cowAni.SetTrigger ("Shoot");
	}

	public void OnFire() {
		cowAni.SetTrigger ("Fire");
	}
}