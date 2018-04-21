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
    public static int numOfBullets = 5;

    //private bool timer_start = false;
    private float start_time;
    private float gum_start_time = -1;
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
            transform.GetComponent<playerAnimation>().Bomb();
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
        if (gum_start_time > 0 && Time.time > gum_start_time + 5f)
        {

            MultiGameControl.instance.frogStop = false;
            this.photonView.RPC("AniGumExpire", PhotonTargets.All);
        }

        if (numOfBullets == 0)
        {
            this.photonView.RPC("AniNoGun", PhotonTargets.All);
        }
    }

    void FixedUpdate()
    {

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

        if (collision.tag == "Bomb")
        {
            Vector3 vector = transform.position - collision.gameObject.transform.position;
            startPos = transform.position;
            endPos = transform.position + (10 / vector.magnitude) * vector;
            journeyLength = Vector3.Distance(startPos, endPos);
            speed = journeyLength;
            start_time = Time.time;
            dizzy = true;
            StartCoroutine(actionFrozen(1));
            GetComponent<HealthScript>().DamagePlayer(20);
        }
        else if (collision.tag == "ChewingGum")
        {
			PhotonNetwork.Destroy (collision.gameObject);
            MultiGameControl.instance.frogStop = true;
            GetComponent<playerAnimation>().StepOnGum();
            gum_start_time = Time.time;

            //GetComponent<playerAnimation> ().GumExpire ();
        }
        else if (collision.tag == "NormalGun")
        {
            Debug.Log("touch NormalGun");
            collision.gameObject.SetActive(false);
            this.photonView.RPC("AniPickGun", PhotonTargets.All);
            withNormalGun = true;
            withFireGun = false;
            withSwapGun = false;
            numOfBullets = 5;
            //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
        }
        else if (collision.tag == "FireGun")
        {
            Debug.Log("touch FireGun");
            collision.gameObject.SetActive(false);
            this.photonView.RPC("AniPickGun", PhotonTargets.All);

            withNormalGun = false;
            withFireGun = true;
            withSwapGun = false;
            numOfBullets = 5;
            //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
        }
        else if (collision.tag == "SwapGun")
        {
            Debug.Log("touch SwapGun");
            collision.gameObject.SetActive(false);
            this.photonView.RPC("AniPickGun", PhotonTargets.All);
            withNormalGun = false;
            withFireGun = false;
            withSwapGun = true;
            numOfBullets = 5;
            //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("withGun");
        }
        else if (collision.tag == "car")
        {
            this.photonView.RPC("AniHitCar", PhotonTargets.All);
            GetComponent<HealthScript>().DamagePlayer(10);
            //            this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerHitCar;
            //            timer_start = true;
            //            start_time = Time.time;
        }
        else if (collision.tag == "alien")
        {
            Debug.Log("Player meets a alien");
			PhotonNetwork.Destroy (collision.gameObject);
            //GetComponent<HealthScript> ().IncreaseBar (20);

            this.photonView.RPC("AniMeetAlien", PhotonTargets.All);

        }
        else if (collision.tag == "Water")
        {
            Debug.Log("Player is in water");
            this.photonView.RPC("AniInWater", PhotonTargets.All);
			GetComponent<HealthScript> ().getInWater ();
        }
        else if (collision.tag == "roof")
        {
            Debug.Log("player is near roof");
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "innerRoof")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.tag == "meat")
        {
            //GetComponent<HealthScript> ().IncreaseBar (7);
            //Destroy (collision.gameObject);
        }
        else if (collision.tag == "bullet")
        {
            GetComponent<HealthScript>().DamagePlayer(30);
            transform.GetComponent<playerAnimation>().ShootByGun();
        }
        else if (collision.tag == "fireball")
        {
            gameObject.GetComponent<MultiHamaJump>().PlayerOnFire();
            GetComponent<HealthScript>().catchFire();
        }
        else if (collision.tag == "SwapEffect")
        {
            transPos(collision.gameObject.GetComponent<BulletScript>().shooter);
        }
    }
    IEnumerator actionFrozen(int duration)
    {
        MultiGameControl.instance.frogStop = true;
        yield return new WaitForSeconds(duration);
        MultiGameControl.instance.frogStop = false;
        dizzy = false;
        transform.localScale = new Vector3(1, 1, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            //            Debug.Log("get collider");
            MultiGameControl.instance.GameOver();
        }
        //		if (collision.tag == "roof") {
        //			Debug.Log ("player leaves the room");
        //			collision.gameObject.SetActive(true);
        //		}
        if (collision.tag == "Water")
        {
            Debug.Log("Player is getting out of water");
            this.photonView.RPC("AniOutWater", PhotonTargets.All);
			GetComponent<HealthScript> ().outWater ();
        }
        if (collision.tag == "innerRoof")
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
    public void transPos(GameObject shooter)
    {
        if (shooter == null || !shooter.tag.Equals("localPlayer"))
        {
            return;
        }
        int temp = transform.GetComponent<HealthScript>().curHealth;
        GetComponent<HealthScript>().setHealth(shooter.transform.GetComponent<HealthScript>().curHealth);
        shooter.transform.GetComponent<HealthScript>().setHealth(temp);
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
    public void PlayerOnFire()
    {
        this.photonView.RPC("PlayerAniFire", PhotonTargets.All);
    }

	public void PlayerNoFire()
	{
		this.photonView.RPC("PlayerAniNoFire", PhotonTargets.All);
	}

    public void PlayerShootByGun()
    {
        this.photonView.RPC("PlayerAniShoot", PhotonTargets.All);
    }

    [PunRPC]
    public void PlayerAniFire()
    {
        transform.GetComponent<playerAnimation>().OnFire();
    }

	[PunRPC]
	public void PlayerAniNoFire(){
		transform.GetComponent<playerAnimation> ().OffFire ();
	}

    [PunRPC]
    public void PlayerAniShoot()
    {
        transform.GetComponent<playerAnimation>().ShootByGun();
    }

    [PunRPC]
    public void AniMeetAlien()
    {
        transform.GetComponent<playerAnimation>().OnMeet();
        StartCoroutine(actionFrozen(2));
        //IncreaseBar (10);
    }

    [PunRPC]
    public void AniPickGun()
    {
        transform.GetComponent<playerAnimation>().GetGun();
    }

    [PunRPC]
    public void AniHitCar()
    {
        transform.GetComponent<playerAnimation>().HitByCar();
    }

    [PunRPC]
    public void AniInWater()
    {
        transform.GetComponent<playerAnimation>().InWater();
    }

    [PunRPC]
    public void AniOutWater()
    {
        transform.GetComponent<playerAnimation>().OutWater();
    }

    [PunRPC]
    public void AniGumExpire()
    {
        GetComponent<playerAnimation>().GumExpire();
    }

    [PunRPC]
    public void AniNoGun()
    {
        GetComponent<playerAnimation>().NoGun();
    }
}