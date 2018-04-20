using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class skillScript : MonoBehaviour {

	public Button bombBtn;
	public Button gumBtn;
	private bool hasBomb = false;
	private bool hasGum = false;
	private int bombCounter = 0;
	private int gumCounter = 0;

	// Use this for initialization

	void Start () {
		bombBtn = GameObject.Find("Canvas/bombBtn").GetComponent<Button>();
		gumBtn = GameObject.Find ("Canvas/gumBtn").GetComponent<Button>();
		bombBtn.gameObject.SetActive (false);
		gumBtn.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bomb" && !hasBomb) 
		{
			bombBtn.gameObject.SetActive (true);
			hasBomb = true;
			bombCounter = 5;
			Destroy (collision.gameObject);
		} 
		else if (collision.tag == "chewingGum" && !hasGum) 
		{
			gumBtn.gameObject.SetActive (true);
			hasGum = true;
			gumCounter = 5;
			Destroy (collision.gameObject);
		}
	}


	public void throwBomb()
	{
		if (bombCounter == 0) 
		{
			hasBomb = false;
			bombBtn.gameObject.SetActive (false);
			return;
		}
		GameObject bomb = PhotonNetwork.Instantiate ("Bomb", transform.position, transform.rotation, 0);
//		Vector3 direction = transform.GetChild (0).transform.position - transform.position;
//		direction /= Vector3.Magnitude (direction);
//		Vector3 startPos = transform.position;
//		Vector3 endPos = transform.position + direction;
//		bomb.transform.position = startPos;

		bombCounter--;
	}

	public void throwGum()
	{
		if (gumCounter == 0) 
		{
			hasGum = false;
			gumBtn.gameObject.SetActive (false);
			return;
		}
		Vector3 startPos = transform.position;
		startPos.y += 50;
		GameObject gum = PhotonNetwork.Instantiate ("ChewingGum", startPos, transform.rotation, 0);

		gumCounter--;
	}
}
