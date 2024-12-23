using System;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    /// <summary>
    /// 玉同士の相殺をするか
    /// </summary>
    public bool m_bColliderBullet;

    public float m_bulletSpeed;

    public bool m_bHitCollider;

    /// <summary>
    /// 玉の当たり判定のレイヤー
    /// </summary>
    public ColliderOptions m_hitOptions;
    [Flags]
    public enum ColliderOptions
    {
        PALYER1,//プレイヤー１に当たる
        PLAYER2,//プレイヤー２に当たる
        BULLET, //玉に当たる
        ALLHIT, //すべてに当たる
    }

    virtual public void Start()
    {
        
    }

    virtual public void Update()
    {
        
    }

    virtual protected void OnBulletHit()
    {

    }
    virtual protected void OnBulletHitUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        OnBulletHit();
    }

    private void OnCollisionStay(Collision collision)
    {
        OnBulletHitUpdate();
    }

}
