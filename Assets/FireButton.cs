using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour {

	public static bool pressFireButton = false;
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		pressFireButton = true;
	}
}
