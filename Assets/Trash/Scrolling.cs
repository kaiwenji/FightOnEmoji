using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
    public float speed = -3f;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
