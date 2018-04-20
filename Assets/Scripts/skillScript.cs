using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class skillScript : MonoBehaviour {

	public Button bombBtn;
	public Button gumBtn;
	private bool hasBomb = false;
	private bool hasGum = false;

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
		} 
		else if (collision.tag == "chewingGum" && !hasGum) 
		{
			gumBtn.gameObject.SetActive (true);
		}
	}


	public void throwBomb()
	{
		GameObject bomb = PhotonNetwork.Instantiate ("Bomb", transform.position, transform.rotation, 0);
		Vector3 direction = transform.GetChild (0).transform.position - transform.position;
		direction /= Vector3.Magnitude (direction);
		Vector3 startPos = transform.position;
		Vector3 endPos = transform.position + 10 * direction;
		bomb.transform.position = endPos;
	}

	public void throwGum()
	{
		Vector3 startPos = transform.position;
		startPos.y += 100;
		GameObject gum = PhotonNetwork.Instantiate ("ChewingGum", startPos, transform.rotation, 0);
	}
}
