using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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
				GetR.AddForce (transform.right * -force);
				//transform.Translate(Vector3.left * Time.deltaTime * force);
            }
            else
            {
                if (move.joystickAxis.y > 0)
                {
					GetR.AddForce (transform.up * force);
					//transform.Translate(Vector3.up * Time.deltaTime * force);
                }
                else
                {
					GetR.AddForce (transform.up * -force);
					//transform.Translate(Vector3.down * Time.deltaTime * force);
                }
            }
        }
        else
        {
            if (Mathf.Abs(move.joystickAxis.x) > Mathf.Abs(move.joystickAxis.y))
            {
				GetR.AddForce (transform.right * force);
				//transform.Translate(Vector3.right * Time.deltaTime * force);
            }
            else
            {
                if (move.joystickAxis.y > 0)
                {
					GetR.AddForce (transform.up * force);
					//transform.Translate(Vector3.up * Time.deltaTime * force);
                }
                else
                {
					GetR.AddForce (transform.up * -force);
					//transform.Translate(Vector3.down * Time.deltaTime * force);
                }
            }
        }


//		void FixedUpdate()
//		{
//			if (!GameControl.instance.frogStop)
//			{
//				if (Input.GetKey(KeyCode.UpArrow))
//				{
//					if (!rb.velocity.Equals(zeroVector))
//					{
//						rb.velocity = zeroVector;
//					}
//					transform.Translate(Vector3.up * Time.deltaTime * force);
//				}
//				if (Input.GetKey(KeyCode.LeftArrow))
//				{
//					if (!rb.velocity.Equals(zeroVector))
//					{
//						rb.velocity = zeroVector;
//					}
//					transform.Translate(Vector3.left * Time.deltaTime * force);
//
//				}
//				if (Input.GetKey(KeyCode.RightArrow))
//				{
//					if (!rb.velocity.Equals(zeroVector))
//					{
//						rb.velocity = zeroVector;
//					}
//					transform.Translate(Vector3.right * Time.deltaTime * force);
//				}
//				if (Input.GetKey(KeyCode.DownArrow))
//				{
//					if (!rb.velocity.Equals(zeroVector))
//					{
//						rb.velocity = zeroVector;
//					}
//					transform.Translate(Vector3.down * Time.deltaTime * force);
//
//				}
//			}
//
//
//
//		}

        //float joyPositionX = move.joystickAxis.x;  

        //float joyPositionY = move.joystickAxis.y;  

        //if (joyPositionY != 0 || joyPositionX != 0)  

        //{  


        //transform.LookAt(new Vector2(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));  


        //transform.Translate(Vector2.forward * Time.deltaTime * 10);  

        //}  

    }

    void onTriggerStay2D(Collision2D other)
    {
        //if(other.gameObject.CompareTag("left")){
        //GetR.velocity = new Vector2 (GetR.velocity.x, 0);
        //	GetR.AddForce (Vector2.left * VelocityLR);
        //}
        //if(other.gameObject.CompareTag("right")){
        //GetR.velocity = new Vector2 (GetR.velocity.x, 0);
        //	GetR.AddForce (Vector2.right * VelocityLR);
        //}

    }

}
