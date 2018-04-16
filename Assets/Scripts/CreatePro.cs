using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePro : MonoBehaviour {
	public GameObject fire_gunPrefab;
	public GameObject normal_gunPrefab;
	public GameObject swap_gunPrefab;
	public GameObject bombObjPrefab;
	public GameObject gumPrefab;
	public GameObject alienPrefab;
	public GameObject bananaPrefab;
	// Use this for initialization
	void Start () {
		fire_gunPrefab = Resources.Load<GameObject>("Prefabs/FireGun");
		normal_gunPrefab = Resources.Load<GameObject>("Prefabs/NormalGun");
		swap_gunPrefab = Resources.Load<GameObject>("Prefabs/SwapGun");
		bombObjPrefab = Resources.Load<GameObject>("Prefabs/bombObj");
		gumPrefab = Resources.Load<GameObject>("Prefabs/gum");
		alienPrefab = Resources.Load<GameObject>("Prefabs/alienPink");
		bananaPrefab = Resources.Load<GameObject>("Prefabs/banana");

		//fire_gun
		Vector2 point1 = new Vector2(Random.Range(-85,-65), Random.Range(-6,20));
		Vector2 point2 = new Vector2(Random.Range(-85,-40), Random.Range(10,20));
		Vector2 point21 = new Vector2(Random.Range(4,-28), Random.Range(36,70));
		Vector2 point22 = new Vector2(Random.Range(-100,-2), Random.Range(-50,-4));
		//normal_gun
		Vector2 point3 = new Vector2(Random.Range(-85,-65), Random.Range(-6,20));
		Vector2 point4 = new Vector2(Random.Range(-85,-40), Random.Range(10,20));
		Vector2 point5 = new Vector2(Random.Range(4,-28), Random.Range(36,70));
		Vector2 point6 = new Vector2(Random.Range(-100,-2), Random.Range(-50,-4));
		Vector2 point7 = new Vector2(Random.Range(-10,60), Random.Range(-55,4));

		//swap_gun
		Vector2 point31 = new Vector2(Random.Range(-85,-65), Random.Range(-6,20));
		Vector2 point32 = new Vector2(Random.Range(-12,70), Random.Range(12,15));
		Vector2 point321 = new Vector2(Random.Range(4,-28), Random.Range(36,70));
		Vector2 point322 = new Vector2(Random.Range(-100,-2), Random.Range(-50,-4));

		//gum
		Vector2 point8 = new Vector2(Random.Range(-80,-20), Random.Range(-20,20));
		Vector2 point9 = new Vector2(Random.Range(39,75), Random.Range(13,70));
		Vector2 point10 = new Vector2(Random.Range(-10,50), Random.Range(44,70));
		Vector2 point11 = new Vector2(Random.Range(10,40), Random.Range(13,15));
		//alien
		Vector2 point12 = new Vector2(Random.Range(-80,-20), Random.Range(-25,20));
		Vector2 point13 = new Vector2(Random.Range(38,70), Random.Range(-20,-7));

		//bomb
		Vector2 point19 = new Vector2(Random.Range(39,75), Random.Range(13,70));
		Vector2 point110 = new Vector2(Random.Range(-10,50), Random.Range(44,70));
		Vector2 point111 = new Vector2(Random.Range(10,40), Random.Range(13,15));

		//banana
		Vector2 point53 = new Vector2(Random.Range(-85,-65), Random.Range(-6,20));
		Vector2 point54 = new Vector2(Random.Range(-85,-40), Random.Range(10,20));
		Vector2 point55 = new Vector2(Random.Range(4,-28), Random.Range(36,70));
		Vector2 point56 = new Vector2(Random.Range(-100,-2), Random.Range(-50,-4));
		Vector2 point57 = new Vector2(Random.Range(-10,60), Random.Range(-55,4));
		GameObject fire_gun1 = GameObject.Instantiate(fire_gunPrefab, point1, fire_gunPrefab.transform.rotation) as GameObject;
		GameObject fire_gun2 = GameObject.Instantiate(fire_gunPrefab, point2, fire_gunPrefab.transform.rotation) as GameObject;
		GameObject fire_gun3 = GameObject.Instantiate(fire_gunPrefab, point21, fire_gunPrefab.transform.rotation) as GameObject;
		GameObject fire_gun4 = GameObject.Instantiate(fire_gunPrefab, point22, fire_gunPrefab.transform.rotation) as GameObject;
		GameObject normal_gun1 = GameObject.Instantiate(normal_gunPrefab, point3, normal_gunPrefab.transform.rotation) as GameObject;
		GameObject normal_gun2 = GameObject.Instantiate(normal_gunPrefab, point4, normal_gunPrefab.transform.rotation) as GameObject;
		GameObject normal_gun3 = GameObject.Instantiate(normal_gunPrefab, point5, normal_gunPrefab.transform.rotation) as GameObject;
		GameObject normal_gun4 = GameObject.Instantiate(normal_gunPrefab, point6, normal_gunPrefab.transform.rotation) as GameObject;
		GameObject normal_gun5 = GameObject.Instantiate(normal_gunPrefab, point7, normal_gunPrefab.transform.rotation) as GameObject;

		GameObject swap_gun1 = GameObject.Instantiate(swap_gunPrefab, point31, swap_gunPrefab.transform.rotation) as GameObject;
		GameObject swap_gun2 = GameObject.Instantiate(swap_gunPrefab, point32, swap_gunPrefab.transform.rotation) as GameObject;
		GameObject swap_gun3 = GameObject.Instantiate(swap_gunPrefab, point321, swap_gunPrefab.transform.rotation) as GameObject;
		GameObject swap_gun4 = GameObject.Instantiate(swap_gunPrefab, point322, swap_gunPrefab.transform.rotation) as GameObject;

		GameObject bomb1 = GameObject.Instantiate(bombObjPrefab, point19, bombObjPrefab.transform.rotation) as GameObject;
		GameObject bomb2 = GameObject.Instantiate(bombObjPrefab, point110, bombObjPrefab.transform.rotation) as GameObject;
		GameObject bomb3 = GameObject.Instantiate(bombObjPrefab, point111, bombObjPrefab.transform.rotation) as GameObject;

		GameObject gum1 = GameObject.Instantiate(gumPrefab, point8, gumPrefab.transform.rotation) as GameObject;
		GameObject gum2 = GameObject.Instantiate(gumPrefab, point9, gumPrefab.transform.rotation) as GameObject;
		GameObject gum3 = GameObject.Instantiate(gumPrefab, point10, gumPrefab.transform.rotation) as GameObject;
		GameObject gum4 = GameObject.Instantiate(gumPrefab, point11, gumPrefab.transform.rotation) as GameObject;

		GameObject alien1 = GameObject.Instantiate(alienPrefab, point12, alienPrefab.transform.rotation) as GameObject;
		GameObject alien2 = GameObject.Instantiate(alienPrefab, point13, alienPrefab.transform.rotation) as GameObject;

		GameObject banana1 = GameObject.Instantiate(bananaPrefab, point3, bananaPrefab.transform.rotation) as GameObject;
		GameObject banana2 = GameObject.Instantiate(bananaPrefab, point4, bananaPrefab.transform.rotation) as GameObject;
		GameObject banana3 = GameObject.Instantiate(bananaPrefab, point5, bananaPrefab.transform.rotation) as GameObject;
		GameObject banana4 = GameObject.Instantiate(bananaPrefab, point6, bananaPrefab.transform.rotation) as GameObject;
		GameObject banana5 = GameObject.Instantiate(bananaPrefab, point7, bananaPrefab.transform.rotation) as GameObject;

	}

	// Update is called once per frame
	void Update () {

	}
}
