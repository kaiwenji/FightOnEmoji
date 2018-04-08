using UnityEngine;
using System.Collections;

/// <summary>
/// 子弹行为
/// </summary>
public class ShotScript : MonoBehaviour
{

    /// <summary>
    /// 造成伤害
    /// </summary>
    public int damage = 10;

    /// <summary>
    /// 子弹归属 , true-敌人的子弹, false-玩家的子弹
    /// </summary>
    public bool isEnemyShot = false;

    // Use this for initialization
    void Start()
    {
        // 2 - 为避免任何泄漏,只给予有限的生存时间.[20秒]
        Destroy(gameObject, 5);
    }
}