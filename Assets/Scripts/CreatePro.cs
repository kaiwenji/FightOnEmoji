using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePro : MonoBehaviour {
	//	public GameObject circle;
//	public GameObject fire_gunPrefab;
//	public GameObject normal_gunPrefab;
//	public GameObject swap_gunPrefab;
//	public GameObject bombObjPrefab;
//	public GameObject gumPrefab;
//	public GameObject alienPrefab;
//	public GameObject bananaPrefab;
	public float timer,timer1;
	public bool created=false;
	//	public CircleScript cs;
	// Use this for initialization
	void Start () {

		timer = 0;
		timer1 = 0;

		initStaticPro ();



	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//8s
		if (timer >= 180) {
			timer = 0;
			Vector2 point1 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point2 = new Vector2 (Random.Range (-85, -40), Random.Range (10, 20));
			Vector2 point21 = new Vector2 (Random.Range (4, -28), Random.Range (36, 70));
			Vector2 point22 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));
			//normal_gun
			Vector2 point3 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point4 = new Vector2 (Random.Range (-85, -40), Random.Range (10, 20));
			Vector2 point5 = new Vector2 (Random.Range (4, -28), Random.Range (36, 70));
			Vector2 point6 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));
			Vector2 point7 = new Vector2 (Random.Range (-10, 60), Random.Range (-55, 4));

			//swap_gun
			Vector2 point31 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point32 = new Vector2 (Random.Range (9, 70), Random.Range (34, 60));
			Vector2 point321 = new Vector2 (Random.Range (-38, 1), Random.Range (24, 38));
			Vector2 point322 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));

			//gum
			Vector2 point8 = new Vector2 (Random.Range (-80, -20), Random.Range (-20, 20));
			Vector2 point9 = new Vector2 (Random.Range (39, 75), Random.Range (13, 70));
			Vector2 point10 = new Vector2 (Random.Range (-10, 50), Random.Range (44, 70));
			Vector2 point11 = new Vector2 (Random.Range (10, 40), Random.Range (13, 15));
			//alien
			Vector2 point12 = new Vector2 (Random.Range (-80, -20), Random.Range (-25, 20));
			Vector2 point13 = new Vector2 (Random.Range (38, 70), Random.Range (-20, -7));
			Vector2 point121 = new Vector2 (Random.Range (-80, -20), Random.Range (-25, 20));
			Vector2 point131 = new Vector2 (Random.Range (38, 70), Random.Range (-20, -7));

			//bomb
			Vector2 point19 = new Vector2 (Random.Range (39, 75), Random.Range (13, 70));
			Vector2 point110 = new Vector2 (Random.Range (-10, 50), Random.Range (44, 70));
			Vector2 point111 = new Vector2 (Random.Range (10, 40), Random.Range (13, 15));


			if (PhotonNetwork.isMasterClient) {
				//Debug.Log("Is client: " + PhotonNetwork.isMasterClient);
				PhotonNetwork.Instantiate("FireGun", point1, transform.rotation, 0);
				PhotonNetwork.Instantiate("FireGun", point2, transform.rotation, 0);
				PhotonNetwork.Instantiate("FireGun", point21, transform.rotation, 0);
				PhotonNetwork.Instantiate("FireGun", point22, transform.rotation, 0);

				PhotonNetwork.Instantiate("NormalGun", point3, transform.rotation, 0);
				GameObject normal_gun2 = PhotonNetwork.Instantiate("NormalGun", point4, transform.rotation, 0);
				GameObject normal_gun3 = PhotonNetwork.Instantiate("NormalGun", point5, transform.rotation, 0);
				GameObject normal_gun4 = PhotonNetwork.Instantiate("NormalGun", point6, transform.rotation, 0);
				GameObject normal_gun5 = PhotonNetwork.Instantiate("NormalGun", point7, transform.rotation, 0);

				GameObject swap_gun1 = PhotonNetwork.Instantiate("SwapGun", point31, transform.rotation, 0);
				GameObject swap_gun2 = PhotonNetwork.Instantiate("SwapGun", point32, transform.rotation, 0);
				GameObject swap_gun3 = PhotonNetwork.Instantiate("SwapGun", point321, transform.rotation, 0);
				GameObject swap_gun4 = PhotonNetwork.Instantiate("SwapGun", point322, transform.rotation, 0);

				GameObject gum1 = PhotonNetwork.Instantiate("gum", point8, transform.rotation, 0);
				GameObject gum2 = PhotonNetwork.Instantiate("gum", point9, transform.rotation, 0);
				GameObject gum3 = PhotonNetwork.Instantiate("gum", point10, transform.rotation, 0);
				GameObject gum4 = PhotonNetwork.Instantiate("gum", point11, transform.rotation, 0);

				GameObject bomb1 = PhotonNetwork.Instantiate("bombObj", point19, transform.rotation, 0);
				GameObject bomb2 = PhotonNetwork.Instantiate("bombObj", point110, transform.rotation, 0);
				GameObject bomb3 = PhotonNetwork.Instantiate("bombObj", point111, transform.rotation, 0);

				GameObject alien1 = PhotonNetwork.Instantiate("alienPink", point12, transform.rotation, 0);
				GameObject alien2 = PhotonNetwork.Instantiate("alienPink", point13, transform.rotation, 0);



			}

		}


	}

	public void initPro(Vector2 center, float radius){
		timer1 += Time.deltaTime;

		if (radius* 6 < 500) {
			//8s
			if (timer1 >= 50) {
				timer1 = 0;
				Debug.Log ("bomb shows");
				if (PhotonNetwork.isMasterClient) {
					//Vector2 center_point = circle.GetComponent<CircleScript> ().getCenter ();
					//float current_radius = circle.GetComponent<CircleScript> ().getRadius () * 6;
					Vector2 point51 = new Vector2 (Random.Range (center.x - radius*3, center.x + radius*3), Random.Range (center.y - radius*3, center.y + radius*3));
					Vector2 point52 = new Vector2 (Random.Range (center.x - radius*3, center.x + radius*3), Random.Range (center.y - radius*3, center.y + radius*3));
					Vector2 point53 = new Vector2 (Random.Range (center.x - radius*3, center.x + radius*3), Random.Range (center.y - radius*3, center.y + radius*3));
					Vector2 point54 = new Vector2 (Random.Range (center.x - radius*3, center.x + radius*3), Random.Range (center.y - radius*3, center.y + radius*3));
					GameObject bomb51 =PhotonNetwork.Instantiate("bombObj", point51, transform.rotation, 0); 
					GameObject alien52 = PhotonNetwork.Instantiate ("alienPink", point52,transform.rotation,0);
					GameObject normal_gun53 = PhotonNetwork.Instantiate ("NormalGun", point53, transform.rotation,0);
					GameObject fire_gun54 = PhotonNetwork.Instantiate ("FireGun", point54, transform.rotation,0);
				}
			}


		}
	}

	public void initStaticPro(){
		//Debug.Log ("call init static function");
		if (PhotonNetwork.isMasterClient && created == false) {
			Vector2 normal1 = new Vector2 ((float)-10.74, (float)48.23);
			Vector2 normal2 = new Vector2 ((float)37.39, (float)-23.26);
			Vector2 normal3 = new Vector2 ((float)-4.03, (float)-2.76);
			Vector2 normal4 = new Vector2 ((float)16.24, (float)-10.93);
			Vector2 normal5 = new Vector2 ((float)53.76, (float)-7.11);
			Vector2 fire1 = new Vector2 ((float)25.2, (float)38.8);
			Vector2 fire2 = new Vector2 ((float)59.25, (float)-29.56);
			Vector2 fire3 = new Vector2 ((float)77.8, (float)21.4);
			Vector2 fire4 = new Vector2 ((float)-47.2, (float)-30.9);
			Vector2 fire5 = new Vector2 ((float)28.43, (float)-52.35001);
			Vector2 swap1 = new Vector2 ((float)-17.4, (float)20.9);
			Vector2 swap2 = new Vector2 ((float)-85.5, (float)-21.6);
			Vector2 swap3 = new Vector2 ((float)46.45, (float)-20.71);
			Vector2 swap4 = new Vector2 ((float)62.4, (float)22.44);
			Vector2 gum1 = new Vector2 ((float)-7.05, (float)-21.64);
			Vector2 gum2 = new Vector2 ((float)-6.802, (float)-7.895);
			Vector2 gum3 = new Vector2 ((float)-33.54, (float)-5.72);
			Vector2 gum4 = new Vector2 ((float)-20.56, (float)-13.26);
			Vector2 gum5 = new Vector2 ((float)-14.32, (float)-0.05);
			Vector2 alien1 = new Vector2 ((float)-0.5, (float)60);
			Vector2 alien2 = new Vector2 ((float)-19.44, (float)9.62);
			Vector2 alien3 = new Vector2 ((float)9.4, (float)2.3);
			Vector2 alien4 = new Vector2 ((float)-4.61, (float)25.29);
			Vector2 alien5 = new Vector2 ((float)20.6, (float)-15.6);
			Vector2 alien6 = new Vector2 ((float)-43.8, (float)1.9);
			Vector2 alien7 = new Vector2 ((float)-76.7, (float)51.1);
			Vector2 alien8 = new Vector2 ((float)26.2, (float)50.6);
			Vector2 alien9 = new Vector2 ((float)28.7, (float)-9.8);
			Vector2 alien10 = new Vector2 ((float)-75.01, (float)-20.08);
			Vector2 alien11 = new Vector2 ((float)-10.22, (float)-38.39001);
			Vector2 alien12 = new Vector2 ((float)-129.3341, (float)-74.7758);
			Vector2 bomb1 = new Vector2 ((float)-10.86597, (float)-65.58364);
			Vector2 bomb2 = new Vector2 ((float)-31.36597, (float)-26.69364);
			Vector2 bomb3 = new Vector2 ((float)34.1, (float)-38.7);
			Vector2 bomb4 = new Vector2 ((float)-33.03288, (float)-43.39917);
			Vector2 bomb5 = new Vector2 ((float)35.4, (float)-19.96);
			Vector2 bomb6 = new Vector2 ((float)9.3, (float)-40.8);
			Vector2 bomb7 = new Vector2 ((float)-50.3, (float)-17.91);
			Vector2 bomb8 = new Vector2 ((float)-86.05, (float)-9.79);
			Vector2 bomb9 = new Vector2 ((float)-46.91, (float)-121.58);
			Vector2 bomb10 = new Vector2 ((float)-56.705, (float)-125.7117);
			Vector2 chewing1 = new Vector2((float)-7.05,(float)-21.64);
			Vector2 chewing2 = new Vector2((float)-6.802,(float)-7.895);
			Vector2 chewing3 = new Vector2((float)-33.54,(float)-5.72);
			Vector2 chewing4 = new Vector2((float)-20.56,(float)-13.26);
			Vector2 chewing5 = new Vector2((float)-14.32,(float)-0.05);
			//Debug.Log ("is client? " + PhotonNetwork.isMasterClient);
			//Debug.Log ("init static property");
			GameObject bombobj1 = PhotonNetwork.Instantiate ("bombObj", bomb1, transform.rotation, 0);
			GameObject bombobj2 = PhotonNetwork.Instantiate ("bombObj", bomb2, transform.rotation, 0); 
			GameObject bombobj3 = PhotonNetwork.Instantiate ("bombObj", bomb3, transform.rotation, 0); 
			GameObject bombobj4 = PhotonNetwork.Instantiate ("bombObj", bomb4, transform.rotation, 0); 
			GameObject bombobj5 = PhotonNetwork.Instantiate ("bombObj", bomb5, transform.rotation, 0); 
			GameObject bombobj6 = PhotonNetwork.Instantiate ("bombObj", bomb6, transform.rotation, 0); 
			GameObject bombobj7 = PhotonNetwork.Instantiate ("bombObj", bomb7, transform.rotation, 0); 
			GameObject bombobj8 = PhotonNetwork.Instantiate ("bombObj", bomb8, transform.rotation, 0); 
			GameObject bombobj9 = PhotonNetwork.Instantiate ("bombObj", bomb9, transform.rotation, 0); 
			GameObject bombobj10 = PhotonNetwork.Instantiate ("bombObj", bomb10, transform.rotation, 0); 
			GameObject alienpink1 = PhotonNetwork.Instantiate ("alienPink", alien1, transform.rotation, 0);
			GameObject alienpink2 = PhotonNetwork.Instantiate ("alienPink", alien2, transform.rotation, 0);
			GameObject alienpink3 = PhotonNetwork.Instantiate ("alienPink", alien3, transform.rotation, 0);
			GameObject alienpink4 = PhotonNetwork.Instantiate ("alienPink", alien4, transform.rotation, 0);
			GameObject alienpink5 = PhotonNetwork.Instantiate ("alienPink", alien5, transform.rotation, 0);
			GameObject alienpink6 = PhotonNetwork.Instantiate ("alienPink", alien6, transform.rotation, 0);
			GameObject alienpink7 = PhotonNetwork.Instantiate ("alienPink", alien7, transform.rotation, 0);
			GameObject alienpink8 = PhotonNetwork.Instantiate ("alienPink", alien8, transform.rotation, 0);
			GameObject alienpink9 = PhotonNetwork.Instantiate ("alienPink", alien9, transform.rotation, 0);
			GameObject alienpink10 = PhotonNetwork.Instantiate ("alienPink", alien10, transform.rotation, 0);
			GameObject alienpink11 = PhotonNetwork.Instantiate ("alienPink", alien11, transform.rotation, 0);
			GameObject alienpink12 = PhotonNetwork.Instantiate ("alienPink", alien12, transform.rotation, 0);
			GameObject normal_gun1 = PhotonNetwork.Instantiate ("NormalGun", normal1, transform.rotation, 0);
			GameObject normal_gun2 = PhotonNetwork.Instantiate ("NormalGun", normal2, transform.rotation, 0);
			GameObject normal_gun3 = PhotonNetwork.Instantiate ("NormalGun", normal3, transform.rotation, 0);
			GameObject normal_gun4 = PhotonNetwork.Instantiate ("NormalGun", normal4, transform.rotation, 0);
			GameObject normal_gun5 = PhotonNetwork.Instantiate ("NormalGun", normal5, transform.rotation, 0);
			GameObject fire_gun1 = PhotonNetwork.Instantiate ("FireGun", fire1, transform.rotation, 0);
			GameObject fire_gun2 = PhotonNetwork.Instantiate ("FireGun", fire2, transform.rotation, 0);
			GameObject fire_gun3 = PhotonNetwork.Instantiate ("FireGun", fire3, transform.rotation, 0);
			GameObject fire_gun4 = PhotonNetwork.Instantiate ("FireGun", fire4, transform.rotation, 0);
			GameObject fire_gun5 = PhotonNetwork.Instantiate ("FireGun", fire5, transform.rotation, 0);
			GameObject swap_gun1 = PhotonNetwork.Instantiate ("SwapGun", swap1, transform.rotation, 0);
			GameObject swap_gun2 = PhotonNetwork.Instantiate ("SwapGun", swap2, transform.rotation, 0);
			GameObject swap_gun3 = PhotonNetwork.Instantiate ("SwapGun", swap3, transform.rotation, 0);
			GameObject swap_gun4 = PhotonNetwork.Instantiate ("SwapGun", swap4, transform.rotation, 0);
			GameObject gewinggum1 = PhotonNetwork.Instantiate ("gum", chewing1, transform.rotation, 0);
			GameObject gewinggum2 = PhotonNetwork.Instantiate ("gum", chewing2, transform.rotation, 0);
			GameObject gewinggum3 = PhotonNetwork.Instantiate ("gum", chewing3, transform.rotation, 0);
			GameObject gewinggum4 = PhotonNetwork.Instantiate ("gum", chewing4, transform.rotation, 0);
			GameObject gewinggum5 = PhotonNetwork.Instantiate ("gum", chewing5, transform.rotation, 0);


			Vector2 point1 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point2 = new Vector2 (Random.Range (-85, -40), Random.Range (10, 20));
			Vector2 point21 = new Vector2 (Random.Range (4, -28), Random.Range (36, 70));
			Vector2 point22 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));
			//normal_gun
			Vector2 point3 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point4 = new Vector2 (Random.Range (-85, -40), Random.Range (10, 20));
			Vector2 point5 = new Vector2 (Random.Range (4, -28), Random.Range (36, 70));
			Vector2 point6 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));
			Vector2 point7 = new Vector2 (Random.Range (-10, 60), Random.Range (-55, 4));

			//swap_gun
			Vector2 point31 = new Vector2 (Random.Range (-85, -65), Random.Range (-6, 20));
			Vector2 point32 = new Vector2 (Random.Range (9, 70), Random.Range (34, 60));
			Vector2 point321 = new Vector2 (Random.Range (-38, 1), Random.Range (24, 38));
			Vector2 point322 = new Vector2 (Random.Range (-100, -2), Random.Range (-50, -4));

			//gum
			Vector2 point8 = new Vector2 (Random.Range (-80, -20), Random.Range (-20, 20));
			Vector2 point9 = new Vector2 (Random.Range (39, 75), Random.Range (13, 70));
			Vector2 point10 = new Vector2 (Random.Range (-10, 50), Random.Range (44, 70));
			Vector2 point11 = new Vector2 (Random.Range (10, 40), Random.Range (13, 15));
			//alien
			Vector2 point12 = new Vector2 (Random.Range (-80, -20), Random.Range (-25, 20));
			Vector2 point13 = new Vector2 (Random.Range (38, 70), Random.Range (-20, -7));

			//bomb
			Vector2 point19 = new Vector2 (Random.Range (39, 75), Random.Range (13, 70));
			Vector2 point110 = new Vector2 (Random.Range (-10, 50), Random.Range (44, 70));
			Vector2 point111 = new Vector2 (Random.Range (10, 40), Random.Range (13, 15));



			Debug.Log ("random create");
			GameObject fire_gun11 = PhotonNetwork.Instantiate ("FireGun", point1, transform.rotation, 0);
			GameObject fire_gun21 = PhotonNetwork.Instantiate ("FireGun", point2, transform.rotation, 0);
			GameObject fire_gun31 = PhotonNetwork.Instantiate ("FireGun", point21, transform.rotation, 0);
			GameObject fire_gun41 = PhotonNetwork.Instantiate ("FireGun", point22, transform.rotation, 0);

			GameObject normal_gun11 = PhotonNetwork.Instantiate ("NormalGun", point3, transform.rotation, 0);
			GameObject normal_gun21 = PhotonNetwork.Instantiate ("NormalGun", point4, transform.rotation, 0);
			GameObject normal_gun31 = PhotonNetwork.Instantiate ("NormalGun", point5, transform.rotation, 0);
			GameObject normal_gun41 = PhotonNetwork.Instantiate ("NormalGun", point6, transform.rotation, 0);
			GameObject normal_gun51 = PhotonNetwork.Instantiate ("NormalGun", point7, transform.rotation, 0);

			GameObject swap_gun11 = PhotonNetwork.Instantiate ("SwapGun", point31, transform.rotation, 0);
			GameObject swap_gun21 = PhotonNetwork.Instantiate ("SwapGun", point32, transform.rotation, 0);
			GameObject swap_gun31 = PhotonNetwork.Instantiate ("SwapGun", point321, transform.rotation, 0);
			GameObject swap_gun41 = PhotonNetwork.Instantiate ("SwapGun", point322, transform.rotation, 0);

			GameObject gum11 = PhotonNetwork.Instantiate ("gum", point8, transform.rotation, 0);
			GameObject gum21 = PhotonNetwork.Instantiate ("gum", point9, transform.rotation, 0);
			GameObject gum31 = PhotonNetwork.Instantiate ("gum", point10, transform.rotation, 0);
			GameObject gum41 = PhotonNetwork.Instantiate ("gum", point11, transform.rotation, 0);

			GameObject bomb11 = PhotonNetwork.Instantiate ("bombObj", point19, transform.rotation, 0);
			GameObject bomb21 = PhotonNetwork.Instantiate ("bombObj", point110, transform.rotation, 0);
			GameObject bomb31 = PhotonNetwork.Instantiate ("bombObj", point111, transform.rotation, 0);

			GameObject alien51 = PhotonNetwork.Instantiate ("alienPink", point12, transform.rotation, 0);
			GameObject alien52 = PhotonNetwork.Instantiate ("alienPink", point13, transform.rotation, 0);


			created = true;
		}

	}

}