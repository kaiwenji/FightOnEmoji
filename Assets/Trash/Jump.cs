using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Jump : MonoBehaviour {


	public float fallMutiplier = 2.5f;
	public float lowJumpMutiplier = 2f;

	public Text countText;
	public Text winText;

	private int waterCount;

	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		waterCount = 0;
		SetCountText ();
		winText.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutiplier - 1) * Time.deltaTime;
		}
	}


	//this function will be called each time we touch a trigger collider
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Water")) {
			other.gameObject.SetActive (false);
			waterCount = waterCount + 1;
			SetCountText ();
		}
	}


	void SetCountText() {
		countText.text = "Water: " + waterCount.ToString ();
		if (waterCount >= 9) {
			winText.text = "You Win!";
		}
	}


}
