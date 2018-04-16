using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepAnimation : MonoBehaviour {

	Animator sheepAni;
	// Use this for initialization
	void Start () {
		sheepAni = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnFire() {
		sheepAni.SetTrigger ("Fire");
	}
}
