using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : MonoBehaviour {

	public Sprite cooked;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void Shoot(){

		transform.GetComponent<cowAnimation> ().Shoot ();
	}

	public void OnFire() {
		transform.GetComponent<cowAnimation> ().OnFire ();
		transform.tag = "meat";
	}
}
