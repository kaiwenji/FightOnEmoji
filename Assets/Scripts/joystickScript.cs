using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickScript : MonoBehaviour
{

    Rigidbody2D GetR;
    //public int VelocityLR = 5;
    public float force;
    // Use this for initialization
    void Start()
    {
        GetR = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {

        EasyTouch.On_TouchStart += On_TouchStart;

        EasyJoystick.On_JoystickMove += OnJoystickMove;

        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;

    }

    // Unsubscribe  

    void OnDisable()
    {

        EasyTouch.On_TouchStart -= On_TouchStart;

    }

    // Unsubscribe  

    void OnDestroy()
    {

        EasyTouch.On_TouchStart -= On_TouchStart;

    }

    // Touch start event  

    public void On_TouchStart(Gesture gesture)
    {

        Debug.Log("Touch in " + gesture.position);

    }


    void OnJoystickMoveEnd(MovingJoystick move)

    {

        if (move.joystickName == "Move")

        {

        }

    }


    void OnJoystickMove(MovingJoystick move)

    {
        Debug.Log("enter");
        if (move.joystickName != "Move")

        {

            return;

        }

        if (move.joystickAxis.x < 0)
        {
            Debug.Log("ok!");
            if (Mathf.Abs(move.joystickAxis.x) > Mathf.Abs(move.joystickAxis.y))
            {
                //GetR.AddForce(transform.right * -force);
                transform.Translate(Vector3.left * Time.deltaTime * force);
            }
            else
            {
                if (move.joystickAxis.y > 0)
                {
                    //GetR.AddForce(transform.up * force);
                    transform.Translate(Vector3.up * Time.deltaTime * force);
                }
                else
                {
                    //GetR.AddForce(transform.up * -force);
                    transform.Translate(Vector3.down * Time.deltaTime * force);
                }
            }
        }
        else
        {
            if (Mathf.Abs(move.joystickAxis.x) > Mathf.Abs(move.joystickAxis.y))
            {
                //GetR.AddForce(transform.right * force);
                transform.Translate(Vector3.right * Time.deltaTime * force);
            }
            else
            {
                if (move.joystickAxis.y > 0)
                {
                    //GetR.AddForce(transform.up * force);
                    transform.Translate(Vector3.up * Time.deltaTime * force);
                }
                else
                {
                    //GetR.AddForce(transform.up * -force);
                    transform.Translate(Vector3.down * Time.deltaTime * force);
                }
            }
        }


    }


}