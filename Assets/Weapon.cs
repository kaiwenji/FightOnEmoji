using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public int Damage = 10;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;
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

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
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

			MultiHamaJump p = hit.collider.GetComponent<MultiHamaJump>();
			if (p != null) {
				p.DamagePlayer (Damage);
				Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
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

	void Effect (Vector3 hitPos) {
		Transform trail = Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation) as Transform;
		LineRenderer lr = trail.GetComponent<LineRenderer> ();

		if (lr != null) 
		{
			//set positions
			lr.SetPosition(0, firePoint.position);
			lr.SetPosition (1, hitPos);
		}
		Destroy (trail.gameObject, 0.02f);

		//Transform clone = Instantiate (MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
		//clone.parent = firePoint;
		//Destroy (clone.gameObject, 0.02f);
	}
}