using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumScript : MonoBehaviour {
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
            Destroy(gameObject);
        }
    }
    public void openCollider()
    {
        collider.SetActive(true);
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
