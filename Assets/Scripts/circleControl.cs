using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;

public class circleControl : Photon.MonoBehaviour {
    public CircleScript outer;
    public CircleScript inner;
    private float startTime;
    private float shrinkTime;
    private bool isShrinked = false;
    private float xSpeed, ySpeed, speed;
    // Use this for initialization
    void Start () {
        speed = 0.001f;
	}
	
	void Update () {
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }
        float delta = Time.time - startTime;
        float shrinkDelta = Time.time - shrinkTime;
        if(isShrinked && shrinkDelta >= .1f)
        {
            this.RpcShrink();
            shrinkTime = Time.time;
        }

        if(delta >= 10f)
        {
            if (isShrinked)
            {
                this.RpcfinishShrink();
                isShrinked = false;
                this.setCenter();
            }
            else
            {
                isShrinked = true;
                this.startShrink();
            }
            startTime = Time.time;
        }
	}
    void startShrink()
    {
        Vector2 speed = inner.getCenter() - outer.getCenter();
        xSpeed = speed.x / 100;
        ySpeed = speed.y / 100;

    }
    void setCenter()
    {
        Vector2 outerCenter = outer.getCenter();
        float innerRadius = inner.getRadius();
        if(innerRadius <= 0.2f)
        {
            return;
        }
        float newx = Random.Range(-2, 2);
        float newy = Random.Range(-2, 2);
        Vector2 innerCenter = outerCenter + new Vector2(newx, newy);
        innerRadius -= .1f;
        this.RpcSetCenter(innerCenter, innerRadius);
    }
    
    void RpcShrink()
    {
        float newRadius = outer.getRadius() - speed;
        Vector2 newCenter = outer.getCenter() + new Vector2(xSpeed, ySpeed);
        outer.setCenter(newCenter);
        outer.setRadius(newRadius);

    }
    void RpcfinishShrink()
    {
        outer.setCenter(inner.getCenter());
        outer.setRadius(inner.getRadius());
    }
    void RpcSetCenter(Vector2 center, float radius)
    {
        inner.setCenter(center);
        inner.setRadius(radius);
    }
}
