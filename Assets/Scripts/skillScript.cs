using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillScript : MonoBehaviour {
    public Texture2D buttonImg;
    public Texture2D pickButtonImg;
    public Vector2 buttonPos = new Vector2(100, -100);
    private string currentSkill = "MultiBomb";
    private GameObject currentTouch;
    private Vector2 buttonSize;
    private bool buttonOn = false;
    private int count = 0;
	// Use this for initialization
	void Start () {
        buttonSize = new Vector2(buttonImg.height, buttonImg.width);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "bomb" || collision.tag == "chewinggum" || collision.tag == "banana")
        {
            Debug.Log(collision.tag);
            currentTouch = collision.gameObject;
            buttonOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonOn = false;
        currentTouch = null;
    }
    private void OnGUI()
    {
        if (buttonOn)
        {
            if (GUI.Button(new Rect(buttonPos, buttonSize), pickButtonImg))
            {
                currentSkill = currentTouch.tag;
                Debug.Log(currentSkill);
                count = 5;
                Destroy(currentTouch);
            }
        }
        if(GUI.Button(new Rect(1100, 350, 100, 100), buttonImg))
        {
            Debug.Log("release bomb");
            if (count > 0)
            {
                PhotonNetwork.Instantiate(currentSkill, transform.position + new Vector3(0, 1.2f, 0), transform.rotation, 0);
                count -= 1;
            }
        }
    }
}
