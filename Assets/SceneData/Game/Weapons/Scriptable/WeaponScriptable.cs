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

    public AutoSkillStatus[] s_autoSkillStatus; 

    public WeaponStatus GetWeaponStatus(int id)
    {
        for (int i = 0; i < s_weaponStatus.Length; i++)
        {
            if ((int)s_weaponStatus[i].s_id == id)
            {
                return s_weaponStatus[i];
            }
        }
        Debug.LogError("NotFoundWeaponID");
        return null;
    }


}
