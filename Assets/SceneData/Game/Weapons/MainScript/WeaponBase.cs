using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{

    public class WeaponBase : MonoBehaviour
    {
        Player.Player m_player1;
        Player.Player m_player2;

        protected WeaponStatus m_baseStatus;


        public virtual void Initialize(Player.Player player1, Player.Player player2)
        {
            m_player1 = player1;
            m_player2 = player2;
        }


        public virtual void Update()
        {
            
        }


        public void Shoot()
        {

        }




    }
}
