using UnityEngine;
using System.Collections;

/// <summary>
/// 发射子弹
/// </summary>
public class WeaponScript : MonoBehaviour
{

    /// <summary>
    /// 子弹预设
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// 两发子弹之间的发射间隔时间
    /// </summary>
    public float shootingRate = 0.25f;

    /// <summary>
    /// 当前冷却时间
    /// </summary>
    private float shootCooldown;

    // Use this for initialization
    void Start()
    {
        // 初始化冷却时间为0
        shootCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 冷却期间实时减少时间
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 射击
    /// </summary>
    /// <param name="isEnemy">是否是敌人的子弹</param>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            if (isEnemy)
            {
                //SoundEffectsHelper.Instance.MakeEnemyShotSound();
            }
            else
            {
                //SoundEffectsHelper.Instance.MakePlayerShotSound();
            }

            shootCooldown = shootingRate;

            if (Input.GetMouseButton(0))
            {
                // 创建一个子弹
                var shotTransform = Instantiate(shotPrefab) as Transform;

                // 指定子弹位置
                shotTransform.position = transform.position;

                // 设置子弹归属
                ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }

                // 设置子弹运动方向
                MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
                if (move != null)
                {
                    // towards in 2D space is the right of the sprite
                    move.direction = this.transform.right;
                }
            }
        }
    }

    /// <summary>
    /// 武器是否准备好再次发射
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}