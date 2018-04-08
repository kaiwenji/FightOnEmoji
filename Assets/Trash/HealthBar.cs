using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public Image currentHealthbar;
	public Text ratioText;

	private float hitpoint;
	private float maxHitpoit = 100;

	public Text winText;


	private void Start() {
		//currentHealthbar = GetComponent<Image> ();
		hitpoint = maxHitpoit;
		UpdateHealthbar ();
		winText.text = "";
	}

	public void UpdateHealthbar() {
		float ratio = hitpoint / maxHitpoit;
		currentHealthbar.rectTransform.localScale = new Vector2 (ratio, 1);
		ratioText.text = (ratio * 100).ToString ("0") + '%';
	}


	// Water evaporates as time passes by
	public void TakeDamage(float damage) {
		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Debug.Log ("Dead!");
			winText.text = "Oops, Mr. Frog is dead!";
		}

		UpdateHealthbar ();
	}

	// When Mr. Frog picks up some waterdrops
	public void HealDamage(float heal) {
		hitpoint += heal;
		if (hitpoint > maxHitpoit) {
			hitpoint = maxHitpoit;
		}

		UpdateHealthbar ();
	}

}
