using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBomb : MonoBehaviour {
    // Use this for initialization
    public Sprite exploImage;
    private int counter = 5;
    private GUIStyle fontStyle;
	void Start () {
        GetComponent<CircleCollider2D>().enabled = false;
        fontStyle = new GUIStyle();
        fontStyle.fontSize = 40;
        fontStyle.fontStyle = FontStyle.Bold;
        fontStyle.normal.textColor = Color.white;
        fontStyle.alignment = TextAnchor.UpperCenter;
        StartCoroutine("loseTime");
	}
	
	// Update is called once per frame
	void Update () {
	}
    IEnumerator loseTime()
    {
        Debug.Log("start count");
        while (true)
        {
            yield return new WaitForSeconds(1);
            counter -= 1;
        }
    }
    IEnumerator explosion()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = exploImage;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void OnGUI()
    {
        if(counter < 0)
        {
            StopCoroutine("loseTime");
            StartCoroutine("explosion");
        }
        else
        {
            GUI.Box(new Rect(transform.position, transform.localScale), counter.ToString(), fontStyle);
        }
    }
}
