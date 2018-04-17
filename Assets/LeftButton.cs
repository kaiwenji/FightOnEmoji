using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour {

	public static bool pressLeftButton = false;
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		pressLeftButton = true;
	}
}
