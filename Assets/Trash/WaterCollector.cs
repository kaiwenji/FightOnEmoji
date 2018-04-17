using System.Collections;
//the details about the UI toolset are held in namespace
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//public variable will show up in the Inspector as an editable property
	//so we can make all of our changes in the editor, instead of return to scripting editor and change value then recompile
	public float speed;

	//hold a reference to the UI text component
	public Text countText;
	public Text winText;

	//create the variable to hold the reference to the rigidbody we want to access
	private Rigidbody rb;

	//hold our count, private => don't have access to it in the Inspector
	private int count;

	//all the code in the Start() is called on the first frame that the script is active. 
	//This is often the very first frame of the game
	void Start() {
		//set reference
		//this will find and return a reference to the attached rigidbody, if there is one
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";

	}

	//called before performing any physics calculations and this is where physics code will go
	void FixedUpdate() {

		//grab the input from our player throught the keyboard
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	//this function will be called each time we touch a trigger collider
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();

		}
	}


	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 9) {
			winText.text = "You Win!";
		}
	}
}