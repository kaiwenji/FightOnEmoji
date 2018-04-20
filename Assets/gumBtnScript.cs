using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gumBtnScript : MonoBehaviour {
	public Button gumBtn;

	// Use this for initialization
	void Start () {
		gumBtn = GetComponent<Button> ();
		gumBtn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GameObject localPlayer = GameObject.FindWithTag("localPlayer");
		if (localPlayer != null) {
			localPlayer.GetComponent<skillScript> ().throwGum();
		}
	}
}
