using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
    //public GameObject camera;
    // Use this for initialization
    void Start()
    {

        if (photonView.isMine)
        {
            gameObject.tag = "localPlayer";
            Debug.Log("ismine");
            GetComponent<MultiHamaJump>().enabled = true;
            //camera.SetActive(true);
        }
        else
        {
            transform.Find("locationMarker").gameObject.SetActive(false);
            //Destroy(transform.GetChild(2).gameObject);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<joystickScript>());
        }
        //GetComponent<MultiHamaJump>().enabled = true;
    }
    

}