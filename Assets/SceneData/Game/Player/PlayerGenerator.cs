using Game.Player;
using Game.Player.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] PlayerScriptable m_playerScript;
    [SerializeField] GameObject m_player;


    void Start()
    {
        GeneratePlayer(m_playerScript.s_player[0], Player.PlayerKind.Player1);
        GeneratePlayer(m_playerScript.s_player[0], Player.PlayerKind.Player2);
    }


    void Update()
    {

    }

    void GeneratePlayer(PlayerStatus playerStatus,Player.PlayerKind player)
    {
        GameObject instance = Instantiate(m_player);
        instance.GetComponent<Player>().Initialize(playerStatus, player);
    }
}
