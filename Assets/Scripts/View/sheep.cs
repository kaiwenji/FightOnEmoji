using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour {
	public Sprite cooked;

	public void Shoot(){

		transform.GetComponent<sheepAnimation> ().Shoot ();
	}

	public void OnFire() {
		transform.GetComponent<sheepAnimation> ().OnFire ();
		transform.tag = "meat";
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            OnFire();
        }
    }
}
