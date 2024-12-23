using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;


namespace Game.Weapon
{

    public class Weapon : MonoBehaviour
    {
        WeaponStatus m_baseStatus;
        WeaponStatus.WeaponType m_weaponKind;


        void Start()
        {

        }

        void Initialize(WeaponStatus weaponStatus)
        {
            m_baseStatus = weaponStatus;
            m_weaponKind = weaponStatus.m_weapon;
        }

        void Update()
        {

        }
    }
}
