using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    private float startTime;
	public int Damage = 1;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime > 0.7)
        {
            Debug.Log("bullet destroyed");
            Destroy(gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other != null) {
			//if we hit a player
			if (other.tag == "Player") {
				other.GetComponent<HealthScript> ().DamagePlayer (Damage);
				Debug.Log ("We hit " + other.name + " and did " + Damage + " damage.");
				other.GetComponent<MultiHamaJump> ().PlayerShootByGun ();

			} 
			//if hit a chicken
			else if (other.tag == "chicken") {
				other.GetComponent<chicken> ().Shoot ();
			} 
			//if hit a pig
			else if (other.tag == "pig") {
				other.GetComponent<pig> ().Shoot ();
			} 
			//if hit a sheep
			else if (other.tag == "sheep") {
				other.GetComponent<sheep> ().Shoot ();
				//if hit a cow
			} else if (other.tag == "cow") {
				other.GetComponent<cow> ().Shoot ();
			}
		}
	}


}
