using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{

    public class Weapon
    {
        WeaponStatus m_baseStatus;
        WeaponStatus.WeaponType m_weaponKind;


        void Initialize(WeaponStatus weaponStatus)
        {
            m_weaponKind = weaponStatus.m_weapon;
        }


        public void Start(Player.Player.PlayerKind player)
        {

        }


        public void Update(Player.Player.PlayerKind player)
        {
            
        }
    }
}
