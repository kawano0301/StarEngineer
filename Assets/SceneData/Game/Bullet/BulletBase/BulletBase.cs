using System;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    /// <summary>
    /// �ʓ��m�̑��E�����邩
    /// </summary>
    public bool m_bColliderBullet;

    public float m_bulletSpeed;

    public bool m_bHitCollider;

    /// <summary>
    /// �ʂ̓����蔻��̃��C���[
    /// </summary>
    public ColliderOptions m_hitOptions;
    [Flags]
    public enum ColliderOptions
    {
        PALYER1,//�v���C���[�P�ɓ�����
        PLAYER2,//�v���C���[�Q�ɓ�����
        BULLET, //�ʂɓ�����
        ALLHIT, //���ׂĂɓ�����
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
