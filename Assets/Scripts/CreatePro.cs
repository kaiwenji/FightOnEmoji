using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePro : MonoBehaviour {
	public GameObject gunPrefab;
	public GameObject bombObjPrefab;
	public GameObject gumPrefab;
	public GameObject alienPrefab;
	// Use this for initialization
	void Start () {
		gunPrefab = Resources.Load<GameObject>("Prefabs/gun");
		bombObjPrefab = Resources.Load<GameObject>("Prefabs/bombobj");
		gumPrefab = Resources.Load<GameObject>("Prefabs/gum");
		alienPrefab = Resources.Load<GameObject>("Prefabs/alien");

		Vector2 point1 = new Vector2(Random.Range(-80,-20), Random.Range(11,40));
		Vector2 point2 = new Vector2(Random.Range(-80,-20), Random.Range(-40,0));
		Vector2 point21 = new Vector2(Random.Range(-80,-20), Random.Range(-40,0));
		Vector2 point22 = new Vector2(Random.Range(-80,-20), Random.Range(-40,0));
		Vector2 point3 = new Vector2(Random.Range(-10,50), Random.Range(30,40));
		Vector2 point4 = new Vector2(Random.Range(-10,50), Random.Range(-10,0));
		Vector2 point5 = new Vector2(Random.Range(-80,-20), Random.Range(0,40));
		Vector2 point6 = new Vector2(Random.Range(-80,-20), Random.Range(-40,0));
		Vector2 point7 = new Vector2(Random.Range(-10,50), Random.Range(11,20));
		//gum
		Vector2 point8 = new Vector2(Random.Range(-80,-20), Random.Range(0,40));
		Vector2 point9 = new Vector2(Random.Range(39,66), Random.Range(0,40));
		Vector2 point10 = new Vector2(Random.Range(-10,50), Random.Range(11,20));
		Vector2 point11 = new Vector2(Random.Range(10,40), Random.Range(11,20));
		//alien
		Vector2 point12 = new Vector2(Random.Range(-80,-20), Random.Range(-30,0));
		Vector2 point13 = new Vector2(Random.Range(5,36), Random.Range(11,20));
		GameObject gun1 = GameObject.Instantiate(gunPrefab, point1, gunPrefab.transform.rotation) as GameObject;
		GameObject gun2 = GameObject.Instantiate(gunPrefab, point2, gunPrefab.transform.rotation) as GameObject;
		GameObject gun3 = GameObject.Instantiate(gunPrefab, point3, gunPrefab.transform.rotation) as GameObject;
		GameObject gun4 = GameObject.Instantiate(gunPrefab, point4, gunPrefab.transform.rotation) as GameObject;
		GameObject gun5 = GameObject.Instantiate(gunPrefab, point21, gunPrefab.transform.rotation) as GameObject;
		GameObject gun6 = GameObject.Instantiate(gunPrefab, point22, gunPrefab.transform.rotation) as GameObject;
		GameObject bomb1 = GameObject.Instantiate(bombObjPrefab, point5, bombObjPrefab.transform.rotation) as GameObject;
		GameObject bomb2 = GameObject.Instantiate(bombObjPrefab, point6, bombObjPrefab.transform.rotation) as GameObject;
		GameObject bomb3 = GameObject.Instantiate(bombObjPrefab, point7, bombObjPrefab.transform.rotation) as GameObject;
		GameObject gum1 = GameObject.Instantiate(gumPrefab, point8, gumPrefab.transform.rotation) as GameObject;
		GameObject gum2 = GameObject.Instantiate(gumPrefab, point9, gumPrefab.transform.rotation) as GameObject;
		GameObject gum3 = GameObject.Instantiate(gumPrefab, point10, gumPrefab.transform.rotation) as GameObject;
		GameObject gum4 = GameObject.Instantiate(gumPrefab, point11, gumPrefab.transform.rotation) as GameObject;
		GameObject alien1 = GameObject.Instantiate(alienPrefab, point12, alienPrefab.transform.rotation) as GameObject;
		GameObject alien2 = GameObject.Instantiate(alienPrefab, point13, alienPrefab.transform.rotation) as GameObject;

	}

	// Update is called once per frame
	void Update () {

	}
}
