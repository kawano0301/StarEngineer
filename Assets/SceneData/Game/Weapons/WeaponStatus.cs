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

        public string s_name;
        public WeaponsID s_id;
        public GameObject s_weaponPrefab;
        public int s_damageValue;
        public float s_coolingTime;


    }
}