using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Weapondata")]
public class WeaponDataScriptable : ScriptableObject
{
    [SerializeField] WeaponData[] m_weapondatas;

    public WeaponData GetWeaponData(string name)
    {
        for (int i = 0; i < m_weapondatas.Length; i++)
        {
            if (m_weapondatas[i].st_name == name)
            {
                return m_weapondatas[i];
            }
        }

        Debug.LogError("NotFindWeapondata  name =" + name);
        return null;
    }
}

[Serializable]
public class WeaponData
{
   public string st_name;
   public float st_shotrate;
   public GameObject st_shotPrefab;
   public Sprite st_icon;
}
