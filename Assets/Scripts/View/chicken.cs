using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken : Photon.MonoBehaviour {
	private bool cooked;

	public void Shoot(){
		this.photonView.RPC ("ChicAniShoot", PhotonTargets.All);
	}

	public void OnFire(){
		this.photonView.RPC ("ChicAniFire", PhotonTargets.All);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Bomb") {
			Debug.Log ("yudaojile6666666");
			OnFire ();
		} else if ((collision.tag == "localPlayer" || collision.tag == "Player") && cooked) {
			this.photonView.RPC ("ChicAniShoot", PhotonTargets.All);
		}
    }

	[PunRPC]
	public void ChicAniShoot() {
		//transform.GetComponent<chickenAnimation> ().Shoot ();
		Destroy(gameObject);
	}

	[PunRPC]
	public void ChicAniFire() {
		transform.GetComponent<chickenAnimation> ().OnFire ();
		transform.tag = "meat";
		cooked = true;
	}
}
