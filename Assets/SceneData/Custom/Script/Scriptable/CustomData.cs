using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create Customdata")]
public class CustomData : ScriptableObject
{
    public PlanetEquipmentData[] m_customData;
}

[Serializable]
public class PlanetEquipmentData
{
    public int st_planetKind;
    public int st_weaponId1;
    public int st_weaponId2;
    public int st_autoId1;
    public int st_autoId2;
}
