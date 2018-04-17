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

	public void InWater() {
		playerAni.SetBool ("inWater", true);
	}

	public void OutWater() {
		playerAni.SetBool ("inWater", false);
	}

	public void ShootByGun() {
        Debug.Log("shoot by gun");
		playerAni.SetTrigger ("ShootByGun");
	}

	public void HitByCar() {
		playerAni.SetTrigger ("HitByCar");
	}

	public void GetGun() {
		playerAni.SetBool ("GetGun", true);
	}

	public void Bomb() {
		playerAni.SetTrigger ("Bomb");
	}

	public void StepOnGum() {
		Debug.Log ("step on Gum");
		playerAni.SetBool ("Gum", true);
	}

	public void GumExpire() {
		playerAni.SetBool ("Gum", false);
	}
}
