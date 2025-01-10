using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{

    public class WeaponBase
    {
        protected WeaponStatus m_baseStatus;


        public virtual void Start(Player.Player player)
        {

        }


        public virtual void Update(Player.Player player)
        {
            
        }
    }
}
