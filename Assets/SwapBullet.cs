using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBullet : MonoBehaviour
{
	private float startTime;
	public int Damage = 1;
	public GameObject shooter = null;
	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
	}

	void Update(){
		if (Time.time > startTime + 0.7f) {
			PhotonNetwork.Destroy (gameObject);
		}
	}

}
