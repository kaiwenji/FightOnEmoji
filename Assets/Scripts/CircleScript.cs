using UnityEngine;
using UnityEngine.Tilemaps;
public class CircleScript : MonoBehaviour {
    public CircleCollider2D cc;
    public Vector3 centroid;
    public float startTime, startTime2;
    private float speed;
    private float rSpeed, cSpeed;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CircleCollider2D>();
        speed = .002f;
        //centroid = getCentroid();
        //centroid.x += 0.5f;
        //centroid.y += 0.5f;
        //transform.position = centroid;
        startTime = Time.time;
	}
	
	// Update is called once per frame
    //[ServerCallback]
	void Update () {
        //if(isShrinked)
        //{
        //if (deltaTime <= 10f)
        //{
        //    if (isShrinked && deltaTime2 >= .1f)
        //    {
        //        reduceRadius();
        //        startTime2 = Time.time;
        //    }
        //}
        //else
        //{
        //    if (isShrinked) {
         
        //        isShrinked = false;
        //        inner.setNewCentroid(this.getCenter(), this.getRadius());
        //        startTime = Time.time;
        //    }
        //    else
        //    {
        //        Vector2 speed = this.getCenter() - inner.getCenter();
        //        this.shrink(speed.x / 100, speed.y / 100);
                    
        //    }
        //}
        //}
	}
    //[ClientRpc]
    public void RpcCall(Vector3 scale, Vector3 position)
    {
        transform.localScale = scale;
        transform.position = position;
    }
    public void reduceRadius()
    {
//        if (!MultiGameControl.instance.gameOver && transform.localScale.x > .1f)
  //      {
            //cc.radius -= .2f;
            transform.localScale -= new Vector3(speed, speed, 0f);
            transform.position -= new Vector3(rSpeed, cSpeed, 0f);
        //RpcCall(transform.localScale, transform.position);
    //    }
    }
    public void shrink(float rSpeed, float cSpeed)
    {
        startTime = Time.time;
        startTime2 = Time.time;
        this.rSpeed = rSpeed;
        this.cSpeed = cSpeed;
    }
    public float getRadius()
    {
        return transform.localScale.x / 2;
    }
    public Vector2 getCenter()
    {
        return transform.position;
    }
    public void setRadius(float radius)
    {
        transform.localScale = new Vector3(radius * 2, radius * 2, 0);
    }
    public void setCenter(Vector2 center)
    {
        transform.position = center;
    }

}
