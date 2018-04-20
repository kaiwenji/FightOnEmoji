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
        if (inWater)
        {
            StopCoroutine(fireHarmPlayer());
            playerOnFire = false;
        }
    }

    public void DamagePlayer(int damage)
    {
        //curHealth -= damage;
        //  if (curHealth <= 0)
        //{
        //kill the player
        if (this.tag.Equals("localPlayer"))
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                MultiGameControl.instance.GameOver();
            }
            this.photonView.RPC("setHealthBar", PhotonTargets.All, curHealth);
        }

        //}


    }
    public void IncreaseBar(int increase)
    {
        if (this.tag.Equals("localPlayer"))
        {
            curHealth = Mathf.Max(curHealth + increase, 100);
            this.photonView.RPC("setHealthBar", PhotonTargets.All, curHealth);
        }

    }
    [PunRPC]
    public void setHealthBar(int health)
    {
        curHealth = health;
        statusIndicator.SetHealth(curHealth, maxHealth);
    }

    public void catchFire()
    {
        StartCoroutine(fireHarmPlayer());
        playerOnFire = true;
    }

    IEnumerator fireHarmPlayer()
    {
        int i = 5;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.5f);
            DamagePlayer(2);
            i--;
        }
    }
}
