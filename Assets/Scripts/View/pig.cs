using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : Photon.MonoBehaviour {
	private bool cooked;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot(){
		        this.photonView.RPC ("PigAniShoot", PhotonTargets.All);
		//        transform.GetComponent<pigAnimation> ().Shoot ();

    }

	public void OnFire() {
		        this.photonView.RPC ("PigAniFire", PhotonTargets.All);
		//        transform.GetComponent<pigAnimation> ().OnFire ();
		//        transform.gameObject.tag = "meat";
	 }

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Bomb")
		{
			OnFire();
		} else if ((collision.tag == "localPlayer" || collision.tag == "Player") && cooked) {
			this.photonView.RPC ("PigAniShoot", PhotonTargets.All);
		}
	}  


	[PunRPC]
	public void PigAniShoot() {
		//transform.GetComponent<pigAnimation> ().Shoot ();
		Destroy(gameObject);
	}

	    
	[PunRPC]
	public void PigAniFire() {
		transform.GetComponent<pigAnimation> ().OnFire ();
		transform.gameObject.tag = "meat";
		cooked = true;
	}

}
