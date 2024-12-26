using Game.Player.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Scriptable/Create Player")]
public class PlayerScriptable : ScriptableObject
{
    public PlayerStatus[] s_player;

}
