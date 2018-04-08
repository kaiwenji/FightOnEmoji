using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyPool : MonoBehaviour {
    public int listSize = 5;
    private GameObject[] list;
    public GameObject listPrefab;
    private Vector2 position = new Vector2(-3f, 5f);
    private float timeSinceLast;
    public float spawnRate = 4f;
    public int current = 0;
	// Use this for initialization
	void Start () {
        list = new GameObject[listSize];
        for(int i = 0; i < listSize; i++)
        {
            list[i] = (GameObject)Instantiate(listPrefab, position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLast += Time.deltaTime;
        if(timeSinceLast >= spawnRate)
        {
            timeSinceLast = 0f;
            list[current].transform.position = position;
            current++;
            if (current >= listSize)
            {
                current = 0;
            }
        }
	}
}
