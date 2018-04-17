using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapScript : MonoBehaviour {
    public Tilemap tm;
	// Use this for initialization
	void Start () {
        tm = GetComponent<Tilemap>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
