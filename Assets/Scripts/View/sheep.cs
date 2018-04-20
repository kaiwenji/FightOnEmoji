using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : Photon.MonoBehaviour {
	private bool cooked;

	public void Shoot(){
		this.photonView.RPC ("SheepAniShoot", PhotonTargets.All);
	}

	public void OnFire() {
		this.photonView.RPC ("SheepAniFire", PhotonTargets.All);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            OnFire();
		} else if ((collision.tag == "localPlayer" || collision.tag == "Player") && cooked) {
			this.photonView.RPC ("SheepAniShoot", PhotonTargets.All);
		}
    }

	[PunRPC]
	public void SheepAniShoot() {
		//transform.GetComponent<sheepAnimation> ().Shoot ();
		Destroy(gameObject);
	}

	[PunRPC]
	public void SheepAniFire() {
		transform.GetComponent<sheepAnimation> ().OnFire ();
		transform.tag = "meat";
		cooked = true;
	}
}
