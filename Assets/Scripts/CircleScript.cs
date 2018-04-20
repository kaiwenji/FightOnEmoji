using UnityEngine;
using UnityEngine.Tilemaps;
public class CircleScript : MonoBehaviour
{
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
