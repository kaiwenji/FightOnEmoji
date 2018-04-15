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
    private bool onTransfer = true;

    private Vector3 startPos;
    private Vector3 endPos;
    private float distance;
    private float speed;
    private float startTime;
    private GameObject obj;
    // Use this for initialization

    void Start () {
        onTransfer = false;
        buttonSize = new Vector2(buttonImg.height, buttonImg.width);
    }
	
	// Update is called once per frame
	void Update () {
        if (onTransfer)
        {
            float distCovered = (Time.time - startTime) * speed;
            float arc = distCovered / distance;
            obj.transform.position = Vector3.Lerp(startPos, endPos, arc);
            if (arc > 0.5)
            {
                obj.transform.localScale -= new Vector3(0.002f, 0.002f, 0);
            }
            else
            {
                obj.transform.localScale += new Vector3(0.002f, 0.002f, 0);
            }
            if (arc >= 1)
            {
                onTransfer = false;
            }

        }
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
                obj = PhotonNetwork.Instantiate(currentSkill, transform.position, transform.rotation, 0);
                startPos = transform.position;
                Vector3 direction = transform.GetChild(0).transform.position - transform.position;
                direction = direction / Vector3.Magnitude(direction);
                endPos = startPos + 10 * direction;
                startTime = Time.time;
                distance = Vector3.Distance(startPos, endPos);
                speed = distance;
                onTransfer = true;
                count -= 1;
            }
        }
    }
}
