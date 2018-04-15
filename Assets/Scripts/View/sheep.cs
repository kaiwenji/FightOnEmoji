using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour {
	public Sprite cooked;

	public void cook(){

		GetComponent<SpriteRenderer> ().sprite = cooked;
	}
}
