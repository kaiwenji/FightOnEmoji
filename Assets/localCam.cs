using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localCam : MonoBehaviour {
	public GameObject player = null;
	private float cameraHeight = -20.0f;
	bool binded = false;

	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindWithTag ("localPlayer");
		} 
		else 
		{
			Vector3 pos = player.transform.position;
			pos.z += cameraHeight;
			transform.position = pos;
		}
	}
}
