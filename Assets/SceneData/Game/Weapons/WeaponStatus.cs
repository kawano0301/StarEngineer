using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon.Status
{
    [Serializable]
    public class WeaponStatus
    {
        public enum WeaponsID
        {
            FIXATION_GUN,
            GOLD_SWORD,
            MISSILE,
            EARTH_QUAKE,
            DRILL_SHOT,
            GAS_CHARGE_SHOT,
            PLASMA_SHOT,
            LIGHTNING_DROP,
            BOOMERANG,
            ROCK_SHOTGUN,
            CHAIN,
            LAND_MINE,
            COOLD_SHOT,
            COOLD_DASH,
            SATELLITE_SLALOM,
            TORNADO,            
        }

        public string m_name;
        public WeaponsID m_id;
        public int m_damageValue;
        public float m_coolingTime;


    }
}