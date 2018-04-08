using UnityEngine;
using System.Collections;

/// <summary>
///  当前游戏对象简单的移动行为
/// </summary>
public class MoveScript : MonoBehaviour
{
    /// <summary>
    /// 物体移动速度
    /// </summary>
    public Vector2 speed = new Vector2(5, 5);

    /// <summary>
    /// 移动方向
    /// </summary>
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 2 - 保存运动轨迹
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // 3 - 让游戏物体移动
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}