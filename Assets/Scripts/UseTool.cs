using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UseTool : MonoBehaviour {
	public GameObject player = null;
	public string itemname;
	public Button ItemButton;
	// Use this for initialization
	void Start () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
		ItemButton.onClick.AddListener (ItemButtonClick);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ItemButtonClick(){
		if (itemname.Equals("fly")) {
			Debug.Log ("Isfly");
			player.GetComponent<HamaJump>().fly ();
			Destroy (this.gameObject);
		}
		if (itemname.Equals( "medicine"))
		{
			Debug.Log ("Ismedicine");
			player.GetComponent<HamaJump>().medicine ();
			Destroy (this.gameObject); 
		}

	}

}
