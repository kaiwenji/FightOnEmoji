using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombBtnScript : MonoBehaviour {
	public Button bombBtn;

	// Use this for initialization
	void Start () {
		bombBtn = GetComponent<Button> ();
		bombBtn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GameObject localPlayer = GameObject.FindWithTag ("localPlayer");
		if (localPlayer != null) {
//			Debug.Log ("throw bomb away");
			localPlayer.GetComponent<skillScript> ().throwBomb ();
		}
	}
}
