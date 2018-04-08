using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiHamaJump : Photon.MonoBehaviour
{
    public Sprite doodle;
    public float force;
    private Vector3 enemyPos;
    private Rigidbody2D rb;
    private Vector3 zeroVector = new Vector3(0, 0, 0);
    //private GameObject MultiGameControl;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //if (!photonView.isMine)
        //{
        //    Destroy(rb);
        //}
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MultiGameControl.instance.frogStop)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!rb.velocity.Equals(zeroVector))
                {
                    rb.velocity = zeroVector;
                }
                transform.Translate(Vector3.up * Time.deltaTime * force);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!rb.velocity.Equals(zeroVector))
                {
                    rb.velocity = zeroVector;
                }
                transform.Translate(Vector3.left * Time.deltaTime * force);

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!rb.velocity.Equals(zeroVector))
                {
                    rb.velocity = zeroVector;
                }
                transform.Translate(Vector3.right * Time.deltaTime * force);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!rb.velocity.Equals(zeroVector))
                {
                    rb.velocity = zeroVector;
                }
                transform.Translate(Vector3.down * Time.deltaTime * force);

            }
        }



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
            StartCoroutine(actionFrozen());
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
            StartCoroutine(actionFrozen());
            int x = Random.Range(-200, 200);
            int y = Random.Range(-200, 200);
            rb.AddForce(new Vector3(x,y,0));
        }
    }
    IEnumerator actionFrozen()
    {
        MultiGameControl.instance.frogStop = true;
        yield return new WaitForSeconds(1);
        MultiGameControl.instance.frogStop = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            Debug.Log("get collider");
            MultiGameControl.instance.GameOver();
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
        StartCoroutine(actionFrozen());
        GetComponent<Rigidbody2D>().AddForce(force);
    }
    


}