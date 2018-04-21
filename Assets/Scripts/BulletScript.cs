using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float startTime;
    public int Damage = 1;
    public GameObject shooter = null;
    // Use this for initialization
    void Start()
    {
       
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.tag == "chick" || other.tag == "chick_square")
            {
                other.gameObject.GetComponent<chicken>().Shoot();
            }
            //if hit a pig
            else if (other.tag == "pig")
            {
                other.gameObject.GetComponent<pig>().Shoot();
            }
            //if hit a sheep
            else if (other.tag == "sheep")
            {
                other.gameObject.GetComponent<sheep>().Shoot();
                //if hit a cow
            }
            else if (other.tag == "cow")
            {
                other.gameObject.GetComponent<cow>().Shoot();
            }
        }
    }


}
