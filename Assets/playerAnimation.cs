﻿using System.Collections;
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
		playerAni.SetBool ("OnFire", true);
	}

	public void OffFire() {
		playerAni.SetBool ("OnFire", false);
	}

	public void InWater() {
		playerAni.SetBool ("inWater", true);
	}

	public void OutWater() {
		playerAni.SetBool ("inWater", false);
	}

	public void ShootByGun() {
		playerAni.SetTrigger ("ShootByGun");
	}

	public void HitByCar() {
		playerAni.SetTrigger ("HitByCar");
	}

	public void GetGun() {
		playerAni.SetBool ("GetGun", true);
	}

    public void NoGun()
    {
        playerAni.SetBool("GetGun", false);
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

	public void Died() {
		playerAni.SetBool ("Died", true);
	}
}
