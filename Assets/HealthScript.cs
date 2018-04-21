using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : Photon.MonoBehaviour
{
    public int maxHealth = 100;
    public int _curHealth;
    public StatusIndicator background;
    public bool playerOnFire = false;
    public bool inWater = false;
	Coroutine lastRoutine = null;


    public int curHealth
    {
        get { return _curHealth; }
        set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    public StatusIndicator statusIndicator;
    // Use this for initialization
    void Start()
    {
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

    void Update()
    {
		if (inWater && playerOnFire)
        {
			GetComponent<MultiHamaJump> ().PlayerNoFire ();
			StopCoroutine(lastRoutine);
            playerOnFire = false;
			GetComponent<joystickScript>().force = 5;
        }
    }

    public void DamagePlayer(int damage)
    {
        if (this.tag.Equals("localPlayer"))
        {
            curHealth -= damage;
            this.photonView.RPC("setHealthBar", PhotonTargets.All, curHealth);
        }


    }

    public void setHealth(int health)
    {
        this.photonView.RPC("setHealthBar", PhotonTargets.All, health);
    }


    public void IncreaseBar(int increase)
    {
        if (this.tag.Equals("localPlayer"))
        {
            curHealth = Mathf.Min(curHealth + increase, 100);
            this.photonView.RPC("setHealthBar", PhotonTargets.All, curHealth);
        }

    }

	public void getInWater(){
		inWater = true;
	}

	public void outWater(){
		inWater = false;
	}
    [PunRPC]
	public void setHealthBar(int health)
    {
        curHealth = health;
        if (curHealth <= 0) {
	//            if (this.tag == "localPlayer") {
	//                MultiGameControl.instance.GameOver ();
	//            }
	            GetComponent<playerAnimation>().Died();
	            GetComponent<MultiHamaJump>().enabled = false;
	            //GetComponent<HealthScript>().enabled = false;
	            GetComponent<skillScript>().enabled = false;
	            transform.GetChild(1).gameObject.SetActive(false);
	            transform.GetChild(2).gameObject.SetActive(false);
	            GetComponent<BoxCollider2D>().enabled = false;
	            //frog.gameObject.tag = "ghost";

	            GameObject fireButton = GameObject.FindWithTag("FireButton");
	            fireButton.gameObject.SetActive (false); 


	        }    
	        statusIndicator.SetHealth(curHealth, maxHealth);
	    }


    public void catchFire()
    {
		lastRoutine = StartCoroutine(fireHarmPlayer());
        playerOnFire = true;
		GetComponent<joystickScript>().force = 20;
    }

    IEnumerator fireHarmPlayer()
    {
        int i = 10;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.5f);
            DamagePlayer(2);
            i--;
        }
		GetComponent<MultiHamaJump> ().PlayerNoFire ();
		GetComponent<joystickScript>().force = 5;
    }
}
