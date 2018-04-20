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
    private bool hasBomb = false;
    private bool hasGum = false;

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
            bomb.transform.position = Vector3.Lerp(startPos, endPos, distCovered / distance);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bomb" && !hasBomb)
        {
            bombBtn.gameObject.SetActive(true);
        }
        else if (collision.tag == "chewingGum" && !hasGum)
        {
            gumBtn.gameObject.SetActive(true);
        }
    }


    public void throwBomb()
    {
        bomb = PhotonNetwork.Instantiate("Bomb", transform.position, transform.rotation, 0);
        Vector3 direction = transform.GetChild(0).transform.position - transform.position;
        direction /= Vector3.Magnitude(direction);
        startPos = transform.position;
        endPos = transform.position + 10 * direction;
        distance = Vector3.Distance(startPos, endPos);
        startTime = Time.time;

        //bomb.transform.position = endPos;
    }

    public void throwGum()
    {
        Vector3 startPos = transform.position;
        startPos.y += 100;
        GameObject gum = PhotonNetwork.Instantiate("ChewingGum", startPos, transform.rotation, 0);
    }
}
