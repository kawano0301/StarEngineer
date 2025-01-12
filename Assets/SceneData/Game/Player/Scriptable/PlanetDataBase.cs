using Game.Player.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable/Create Player")]

public class PlanetDataBase : ScriptableObject
{
    public PlayerStatus[] s_playerStatus;

}
