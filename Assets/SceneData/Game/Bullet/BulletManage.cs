using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ã ÇÃä«óùÉNÉâÉX
/// </summary>
public class BulletManage : MonoBehaviour
{
    [SerializeField] Player m_player1;
    [SerializeField] Player m_player2;
    List<BulletBase> m_bulletList = new List<BulletBase>();

    public void AddBullet(BulletBase bulletBase)
    {
        m_bulletList.Add(bulletBase);
    }

    public void RemoveShotList(BulletBase bulletBase)
    {
        m_bulletList.Remove(bulletBase);
    }

    private void Update()
    {
        for (int i = 0; i < m_bulletList.Count; i++)
        {
            m_bulletList[i].Update();
        }
    }

}
