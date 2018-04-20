using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cow : Photon.MonoBehaviour {

	private bool cooked;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void Shoot(){
		this.photonView.RPC ("CowAniShoot", PhotonTargets.All);
	}

	public void OnFire() {
		this.photonView.RPC ("CowAniFire", PhotonTargets.All);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb")
        {
            OnFire();
		} else if ((collision.tag == "localPlayer" || collision.tag == "Player") && cooked) {
			this.photonView.RPC ("CowAniShoot", PhotonTargets.All);
		}
    }

	[PunRPC]
	public void CowAniShoot() {
		//transform.GetComponent<cowAnimation> ().Shoot ();
		Destroy(gameObject);
	}

	[PunRPC]
	public void CowAniFire() {
		transform.GetComponent<cowAnimation> ().OnFire ();
		transform.tag = "meat";
		cooked = true;
	}
}
