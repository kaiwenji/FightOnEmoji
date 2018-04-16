using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiHamaJump : Photon.MonoBehaviour
{
    //public Sprite PlayerHitCar;
    //public Sprite MainCharacter;
    public static bool withNormalGun = false;
    public static bool withFireGun = false;
    public static bool withSwapGun = false;
    //private bool timer_start = false;
    private float start_time;
    //private float interval = 1f;
    public Sprite doodle;
    public float force;
    private Vector3 enemyPos;
    private Rigidbody2D rb;
    private Vector3 zeroVector = new Vector3(0, 0, 0);

    private float speed;
    private Vector3 startPos;
    private Vector3 endPos;
    private float journeyLength;
    private bool dizzy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (dizzy)
        {
            float distCovered = (Time.time - start_time) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
            transform.Rotate(new Vector3(0, 0, 15));
            if (fracJourney > 0.5)
            {
                transform.localScale -= new Vector3(0.05F, 0.05F, 0);
            }
            else
            {
                transform.localScale += new Vector3(0.05F, 0.05F, 0);
            }

        }
    }

    void FixedUpdate()
    {
        if (!MultiGameControl.instance.frogStop)
        {
          
			if (LeftButton.pressLeftButton)
            {
				transform.Rotate (Vector3.forward * 6);
				LeftButton.pressLeftButton = false;
            }
			if (RightButton.pressRightButton)
            {
				transform.Rotate (Vector3.back * 6);
				RightButton.pressRightButton = false;
            }
            //if (timer_start == true)
            //{
            //    if (Time.time > start_time + interval)
            //    {
            //        DamagePlayer(10);
            //        timer_start = false;
            //        this.GetComponent<SpriteRenderer>().sprite = MainCharacter;
            //    }
            //}

        }

       // DamagePlayer(10);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            //string localName = GetComponent<PhotonView>().owner.name;
            //string collisionName = collision.gameObject.GetComponent<PhotonView>().owner.name;
            //collision.gameObject.name = "enemyPlayer";
            //MultiGameControl.instance.startVs(localName, collisionName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

		if (collision.tag == "Bomb") {
			Debug.Log ("touch bomb");
			Vector3 vector = transform.position - collision.gameObject.transform.position;
			startPos = transform.position;
			endPos = transform.position + (10 / vector.magnitude) * vector;
			journeyLength = Vector3.Distance (startPos, endPos);
			speed = journeyLength;
			start_time = Time.time;
			dizzy = true;
			StartCoroutine (actionFrozen (1));
		} else if (collision.tag == "ChewingGum") {
			collision.gameObject.GetComponent<gumScript> ().openCollider ();
		} else if (collision.tag == "Banana") {
			Debug.Log ("touch banana");
			StartCoroutine (actionFrozen (1));
			int x = Random.Range (-200, 200);
			int y = Random.Range (-200, 200);
			rb.AddForce (new Vector3 (x, y, 0));
		} else if (collision.tag == "NormalGun") {
			Debug.Log ("touch NormalGun");
			collision.gameObject.SetActive (false);
			transform.GetComponent<playerAnimation> ().GetGun ();
			withNormalGun = true;
			withFireGun = false;
			withSwapGun = false;
			//GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
		} else if (collision.tag == "FireGun") {
			Debug.Log ("touch FireGun");
			collision.gameObject.SetActive (false);
			transform.GetComponent<playerAnimation> ().GetGun ();
			withNormalGun = false;
			withFireGun = true;
			withSwapGun = false;
			//GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
		} else if (collision.tag == "SwapGun") {
			Debug.Log ("touch SwapGun");
			collision.gameObject.SetActive (false);
			transform.GetComponent<playerAnimation> ().GetGun ();
			withNormalGun = false;
			withFireGun = false;
			withSwapGun = true;
			//GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
		} else if (collision.tag == "car") {
			transform.GetComponent<playerAnimation> ().HitByCar ();
			GetComponent<HealthScript> ().DamagePlayer (10);
			//            this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerHitCar;
			//            timer_start = true;
			//            start_time = Time.time;
		} else if (collision.tag == "alien") {
			Debug.Log ("Player meets a alien");
			Destroy (collision.gameObject);
			transform.GetComponent<playerAnimation> ().OnMeet ();
			StartCoroutine (actionFrozen (1));
			//IncreaseBar (10);
			GetComponent<HealthScript> ().IncreaseBar (10);
		} else if (collision.tag == "Water") {
			Debug.Log ("Player is in water");
			transform.GetComponent<playerAnimation> ().InWater ();
		} else if (collision.tag == "roof") {
			Debug.Log ("player is near roof");
			collision.gameObject.SetActive (false);
		} else if (collision.tag == "innerRoof") {
			collision.gameObject.transform.GetChild (0).gameObject.SetActive (false);
		} else if (collision.tag == "meat") {
			GetComponent<HealthScript> ().IncreaseBar (5);
			Destroy (collision.gameObject);
		}
    }
	IEnumerator actionFrozen(int duration)
    {
        MultiGameControl.instance.frogStop = true;
        yield return new WaitForSeconds(duration);
        MultiGameControl.instance.frogStop = false;
        dizzy = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            Debug.Log("get collider");
            MultiGameControl.instance.GameOver();
        }
//		if (collision.tag == "roof") {
//			Debug.Log ("player leaves the room");
//			collision.gameObject.SetActive(true);
//		}
		if (collision.tag == "Water") {
			Debug.Log ("Player is getting out of water");
			transform.GetComponent<playerAnimation> ().OutWater ();
		}
        if(collision.tag == "innerRoof")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void checkWhoWin(bool isMasterWin)
    {
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }
        if (isMasterWin)
        {
            Debug.Log("masterwin");
            this.photonView.RPC("stepBack", PhotonTargets.Others);

        }
        else
        {
            Debug.Log("start stepback");
            this.stepBack();
            //this.photonView.RPC("stepBack", PhotonTargets.MasterClient);
        }
    }

    [PunRPC]
    public void stepBack()
    {
        enemyPos = GameObject.FindWithTag("Player").transform.position;
         Vector3 pos = transform.position - enemyPos;
        if (!photonView.isMine)
        {
            return;
        }
        Vector3 force = pos * 100;
        StartCoroutine(actionFrozen(1));
        GetComponent<Rigidbody2D>().AddForce(force);
    }


	//Animation Part
	public void PlayerOnFire() {
		transform.GetComponent<playerAnimation> ().OnFire ();
	}
//	public void ChickenOnFire() {
//		transform.GetComponent<chickenAnimation> ().OnFire ();
//	}
//
//	public void PigOnFire() {
//		transform.GetComponent<pigAnimation> ().OnFire ();
//	}
//
//	public void SheepOnFire() {
//		transform.GetComponent<sheepAnimation> ().OnFire ();
//	}
//
//	public void CowOnFire() {
//		transform.GetComponent<cowAnimation> ().OnFire ();
//	}

}