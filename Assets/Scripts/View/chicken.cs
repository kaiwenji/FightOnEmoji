﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : MonoBehaviour {
	public Sprite cooked;

	public void Shoot(){
		
//		transform.GetComponent<chickenAnimation> ().Shoot ();
		Destroy (transform.gameObject);

	}
	public void OnFire(){
		transform.GetComponent<chickenAnimation> ().OnFire ();

		transform.tag = "meat";
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            Debug.Log("yudaojile6666666");
            OnFire();
        }
    }
}
