using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiHamaJump : Photon.MonoBehaviour
{
    public Sprite PlayerHitCar;
    public Sprite MainCharacter;
    private bool timer_start = false;
    private float start_time;
    private float interval = 1f;
    public Sprite doodle;
    public float force;
    private Vector3 enemyPos;
    private Rigidbody2D rb;
    private Vector3 zeroVector = new Vector3(0, 0, 0);
    public int maxHealth = 100;
    public int _curHealth;
    

    public int curHealth
    {
        get { return _curHealth; }
        set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    [SerializeField]
    private StatusIndicator statusIndicator;
    //private GameObject MultiGameControl;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //if (!photonView.isMine)
        //{
        //    Destroy(rb);
        //}
        curHealth = maxHealth;
        if (statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth(curHealth, maxHealth);
        }
    }
    // Update is called once per frame
    void Update()
    {
//        // 5 - 射击
//        bool shoot = Input.GetButtonDown("Fire1");
//        shoot |= Input.GetButtonDown("Fire2");
//        // 小心：对于Mac用户，按Ctrl +箭头是一个坏主意
//
//        if (shoot)
//        {
//            WeaponScript weapon = GetComponent<WeaponScript>();
//            if (weapon != null)
//            {
//                weapon.Attack(false);
//            }
//        }

        
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
            if (timer_start == true)
            {
                if (Time.time > start_time + interval)
                {
                    DamagePlayer(10);
                    timer_start = false;
                    this.GetComponent<SpriteRenderer>().sprite = MainCharacter;
                }
            }

        }

       // DamagePlayer(10);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            Debug.Log("touch player");
            if (PhotonNetwork.isMasterClient)
            {
                MultiGameControl.instance.startVs();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fountain")
        {
            //MultiGameControl.instance.success();
        }
        if (collision.tag == "Water")
        {
            //MultiGameControl.instance.CmdDied(isLocalPlayer);
            //MultiGameControl.instance.frogDied();
        }
        if(collision.tag == "MultiBomb")
        {
            Debug.Log("touch bomb");
            StartCoroutine(actionFrozen(1));
            Vector3 vector = transform.position - collision.gameObject.transform.position;
            rb.AddForce((300 / vector.magnitude) * vector);
        }
        if(collision.tag == "ChewingGum")
        {
            collision.gameObject.GetComponent<gumScript>().openCollider();
        }
        if(collision.tag == "Banana")
        {
            Debug.Log("touch banana");
            StartCoroutine(actionFrozen(1));
            int x = Random.Range(-200, 200);
            int y = Random.Range(-200, 200);
            rb.AddForce(new Vector3(x,y,0));
        }

        if (collision.tag == "SwapGun")
        {
            Debug.Log("touch SwapGun");
            collision.gameObject.SetActive(false);
			transform.GetComponent<playerAnimation> ().GetGun ();
            //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
        }
        if (collision.tag == "car")
        {
			transform.GetComponent<playerAnimation> ().HitByCar ();
			DamagePlayer (10);
//            this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerHitCar;
//            timer_start = true;
//            start_time = Time.time;
        }
		if (collision.tag == "alien") {
			Debug.Log ("Player meets a alien");
			Destroy (collision.gameObject);
			transform.GetComponent<playerAnimation> ().OnMeet ();
			StartCoroutine(actionFrozen(1));
			IncreaseBar (10);
		}
		if (collision.tag == "Water") {
			Debug.Log ("Player is in water");
			transform.GetComponent<playerAnimation> ().InWater ();
		}
		if (collision.tag == "roof") {
			Debug.Log ("player is near roof");
			collision.gameObject.SetActive(false);
		}
        if (collision.tag == "innerRoof")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
	IEnumerator actionFrozen(int duration)
    {
        MultiGameControl.instance.frogStop = true;
        yield return new WaitForSeconds(duration);
        MultiGameControl.instance.frogStop = false;
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
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            //kill the player
            MultiGameControl.instance.GameOver();
        }

        statusIndicator.SetHealth(curHealth, maxHealth);
    }
    public void IncreaseBar(int increase)
    {
        curHealth += increase;
        statusIndicator.SetHealth(curHealth, maxHealth);
    }

	public void ChickenOnFire() {
		transform.GetComponent<chickenAnimation> ().OnFire ();
	}


}