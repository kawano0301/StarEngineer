using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create Weapon")]

public class WeaponScriptable : ScriptableObject
{
    [Header("����ݒ�")]
    public WeaponStatus[] s_weaponStatus;

}
