using System.Collections;
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
		//make the gun follow mouse position
		if (transform.parent.tag == "localPlayer" && MultiHamaJump.withNormalGun) {
			if (FireButton.pressFireButton && Time.time > timeToFire) {
				timeToFire = Time.time + fireInterval;
				Shoot ();
				FireButton.pressFireButton = false;
			}
		} 
		else if (transform.parent.tag == "localPlayer" && MultiHamaJump.withFireGun) {
			if (fireRate == 0) {
				if (FireButton.pressFireButton) {
					ShootFireBall ();
					FireButton.pressFireButton = false;
				}
			} else {
				if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRate;
					ShootFireBall ();
				}
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
}