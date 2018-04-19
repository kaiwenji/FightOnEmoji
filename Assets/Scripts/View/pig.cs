using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour {
	public Sprite cooked;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Shoot(){

		transform.GetComponent<pigAnimation> ().Shoot ();

	}

	public void OnFire() {
		transform.GetComponent<pigAnimation> ().OnFire ();
		transform.gameObject.tag = "meat";
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            OnFire();
        }
    }
}
