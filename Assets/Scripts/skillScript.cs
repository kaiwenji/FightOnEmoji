using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillScript : MonoBehaviour
{
    private Vector3 startPos, endPos;
    private float distance;
    private float speed = 10f;
    private float startTime = -1;
    private GameObject bomb;
    public Button bombBtn;
    public Button gumBtn;
    public bool hasBomb = false;
    public bool hasGum = false;
	public int bombCounter = 0;
	public int gumCounter = 0;


    // Use this for initialization

    void Start()
    {
        bombBtn = GameObject.Find("Canvas/bombBtn").GetComponent<Button>();
        gumBtn = GameObject.Find("Canvas/gumBtn").GetComponent<Button>();
        bombBtn.gameObject.SetActive(false);
        gumBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime > 0)
        {
            float distCovered = speed * (Time.time - startTime);
            if (distCovered == distance)
            {
                startTime = -1;
                return;
            }
            Debug.Log(distCovered / distance);
			if (bomb != null) {
				bomb.transform.position = Vector3.Lerp(startPos, endPos, distCovered / distance);
			}
        }

    }


    public void throwBomb()
    {
		if (bombCounter <= 0) {
			hasBomb = false;
			bombBtn.gameObject.SetActive(false);
			return;
		}
        bomb = PhotonNetwork.Instantiate("Bomb", transform.position, transform.rotation, 0);
        Vector3 direction = transform.GetChild(0).transform.position - transform.position;
        direction /= Vector3.Magnitude(direction);
        startPos = transform.position;
        endPos = transform.position + 10 * direction;
        distance = Vector3.Distance(startPos, endPos);
        startTime = Time.time;

        //bomb.transform.position = endPos;
		bombCounter--;
    }

    public void throwGum()
    {
		if (gumCounter <= 0) 
		{
			hasGum = false;
			gumBtn.gameObject.SetActive(false);
			return;
		}
		Vector3 startPos = transform.position - transform.GetChild(0).transform.position;
		startPos = transform.position + startPos * 3 / startPos.magnitude;
        GameObject gum = PhotonNetwork.Instantiate("ChewingGum", startPos, transform.rotation, 0);

		gumCounter--;
    }
}
