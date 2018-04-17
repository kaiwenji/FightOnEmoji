using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightButton : MonoBehaviour {

	public static bool pressRightButton = false;
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		pressRightButton = true;
	}
}
