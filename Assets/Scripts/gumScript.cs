using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumScript : MonoBehaviour {
	//sprite to make gum monster seems disappear
	public Sprite touming;

    private int counter = 5;
    public GameObject collider;
    void Start()
    {
        StartCoroutine("loseTime");
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < 0)
        {
			GameObject.FindWithTag ("localPlayer").GetComponent<playerAnimation> ().GumExpire ();
            Destroy(gameObject);
        }
    }
    public void openCollider()
    {
        collider.SetActive(true);
		GetComponent<SpriteRenderer> ().sprite = touming;
		GameObject.FindWithTag ("localPlayer").GetComponent<playerAnimation> ().StepOnGum ();

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
}
