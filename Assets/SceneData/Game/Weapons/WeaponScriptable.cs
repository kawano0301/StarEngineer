using Game.Weapon;
using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create Weapon")]

public class WeaponScriptable : ScriptableObject
{
    [Header("•Šíİ’è")]
    public WeaponStatus[] s_weaponStatus;


    void TestWeaponControl()
    {
        for (int i = 0; i < s_weaponStatus.Length; i++)
        {
            switch (s_weaponStatus[i].m_id)
            {
                case WeaponStatus.WeaponsID.FIXATION_GUN:
                    break;
                case WeaponStatus.WeaponsID.GOLD_SWORD:
                    break;
                case WeaponStatus.WeaponsID.MISSILE:
                    break;
                case WeaponStatus.WeaponsID.EARTH_QUAKE:
                    break;
                case WeaponStatus.WeaponsID.DRILL_SHOT:
                    break;
                case WeaponStatus.WeaponsID.GAS_CHARGE_SHOT:
                    break;
                case WeaponStatus.WeaponsID.PLASMA_SHOT:
                    break;
                case WeaponStatus.WeaponsID.LIGHTNING_DROP:
                    break;
                case WeaponStatus.WeaponsID.BOOMERANG:
                    break;
                case WeaponStatus.WeaponsID.ROCK_SHOTGUN:
                    break;
                case WeaponStatus.WeaponsID.CHAIN:
                    break;
                case WeaponStatus.WeaponsID.LAND_MINE:
                    break;
                case WeaponStatus.WeaponsID.COOLD_SHOT:
                    break;
            }
        }
    }


}
