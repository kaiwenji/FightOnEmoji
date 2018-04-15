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
			if (fireRate == 0) {
				if (FireButton.pressFireButton) {
					Shoot ();
					FireButton.pressFireButton = false;
				}
			} else {
				if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRate;
					Shoot ();
				}
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

		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 originPosition = new Vector2(playerLocation.position.x, playerLocation.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, firePointPosition - originPosition, 100, whatToHit);
		//Debug.DrawLine (firePointPosition, (firePointPosition - originPosition)*100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");

			//if we hit a player
			if (hit.collider.tag == "Player") {
				hit.collider.GetComponent<HealthScript> ().DamagePlayer (Damage);
				Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
			} 
			//if hit a chicken
			else if (hit.collider.tag == "chicken") {
				hit.collider.GetComponent<chicken> ().cook ();
			} 
			//if hit a pig
			else if (hit.collider.tag == "pig") {
				hit.collider.GetComponent<pig> ().cook ();
			} 
			//if hit a sheep
			else if (hit.collider.tag == "sheep") {
				hit.collider.GetComponent<sheep> ().cook ();
			}
		}

		if (Time.time >= timeToSpawnEffect) {
			Vector3 hitPos;
			if (hit.collider == null) {
				hitPos = (firePointPosition - originPosition) * 100;
			} else {
				hitPos = hit.point;
			}
			Effect (hitPos);
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
	}

	void ShootFireBall(){
		Transform clone = Instantiate (FireBallPrefab, firePoint.position, firePoint.rotation) as Transform;
		clone.parent = firePoint;
		Destroy (clone.gameObject, 0.5f);
	}

	void Effect (Vector3 hitPos) {
        GameObject trail = PhotonNetwork.Instantiate("BulletTrail", firePoint.position, firePoint.rotation, 0);
        //LineRenderer lr = trail.GetComponent<LineRenderer> ();

        //if (lr != null) 
        //{
        //set positions
        //lr.SetPosition(0, firePoint.position);
        //lr.SetPosition (1, hitPos);
        //}
        Destroy (trail, 0.02f);
	}
}