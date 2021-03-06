﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public int Damage = 10;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;
	public Transform FireBallPrefab;
	//public Transform MuzzleFlashPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;

	float timeToFire = 0;
	float fireInterval = 0.5f;
	Transform firePoint;
	Transform playerLocation;


	// Use this for initialization
	void Awake () {
		firePoint = transform;
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
		playerLocation = transform.parent;
	}

	// Update is called once per frame
	void Update () {
        if (FireButton.pressFireButton && MultiHamaJump.numOfBullets == 0)
        {
//            Debug.Log("meizidanl");
            FireButton.pressFireButton = false;
            GameObject root = GameObject.Find("Canvas");
            root.transform.Find("Toast").gameObject.SetActive(true);
            Invoke("hideToast", 1);
        }
        //make the gun follow mouse position
        if (transform.parent.tag == "localPlayer" && MultiHamaJump.withNormalGun) {
			if (FireButton.pressFireButton && Time.time > timeToFire && MultiHamaJump.numOfBullets > 0) {
				timeToFire = Time.time + fireInterval;
				Shoot ();
				FireButton.pressFireButton = false;
                MultiHamaJump.numOfBullets--;
			}
		} 
		else if (transform.parent.tag == "localPlayer" && MultiHamaJump.withFireGun) {
			if (FireButton.pressFireButton && MultiHamaJump.numOfBullets > 0) {
				ShootFireBall ();
				FireButton.pressFireButton = false;
                MultiHamaJump.numOfBullets--;
			}
        }
        else if (transform.parent.tag == "localPlayer" && MultiHamaJump.withSwapGun)
        {
            if (FireButton.pressFireButton && Time.time > timeToFire && MultiHamaJump.numOfBullets > 0)
            {
                timeToFire = Time.time + fireInterval;
                ShootSwapEffect();
				FireButton.pressFireButton = false;

                MultiHamaJump.numOfBullets--;
            }
        }
    }

	void Shoot () {
		GameObject trail = PhotonNetwork.Instantiate("BulletTrail", firePoint.position, firePoint.rotation, 0);
		Vector3 direction = firePoint.position - firePoint.parent.position;
		direction = direction * 20 / direction.magnitude;
		trail.GetComponent<Rigidbody2D>().velocity = direction * 10;
		Destroy (trail.gameObject, 0.5f);
	}

	void ShootFireBall(){
		GameObject fire = PhotonNetwork.Instantiate ("FireBall", firePoint.position, firePoint.rotation, 0);
		Debug.Log ("fire pos:" + fire.transform.position);
		fire.transform.position = firePoint.position;
	}

    void ShootSwapEffect()
    {
        GameObject fire = PhotonNetwork.Instantiate("SwapEffect", firePoint.position, firePoint.rotation, 0);
        Vector3 direction = firePoint.position - firePoint.parent.position;
        direction = direction * 20 / direction.magnitude;
        fire.GetComponent<Rigidbody2D>().velocity = direction * 5;

		fire.transform.GetComponent<SwapBullet>().shooter = transform.parent.gameObject;
    }

    void hideToast()
    {
        GameObject root = GameObject.Find("Canvas");
        root.transform.Find("Toast").gameObject.SetActive(false);
    }
}