using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaScript : MonoBehaviour {
    private int counter = 5;
    void Start()
    {
        StartCoroutine("loseTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 0)
        {
            Destroy(gameObject);
        }
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
