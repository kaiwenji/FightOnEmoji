using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
    //public GameObject camera;
    // Use this for initialization
    public new GameObject camera;
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
            camera.SetActive(false);
            Destroy(GetComponent<Rigidbody2D>());
        }
        //GetComponent<MultiHamaJump>().enabled = true;
    }
    

}