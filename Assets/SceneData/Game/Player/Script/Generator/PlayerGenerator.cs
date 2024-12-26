using Game.Player;
using Game.Player.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] PlayerScriptable m_playerScript;
    [SerializeField] GameObject m_player;

    Vector3 m_player1Pos = new Vector3(-1, 0, 0);
    Vector3 m_player2Pos = new Vector3(1, 0, 0);


    void Start()
    {
        InstancePlayer(m_playerScript.s_player[0], Player.PlayerKind.Player1, m_player1Pos);
        InstancePlayer(m_playerScript.s_player[0], Player.PlayerKind.Player2, m_player2Pos);
    }


    void Update()
    {

    }

    GameObject InstancePlayer(PlayerStatus playerStatus,Player.PlayerKind playerKind,Vector3 instancePosition)
    {
        GameObject instance = Instantiate(m_player, instancePosition ,Quaternion.identity);
        instance.GetComponent<Player>().Initialize(playerStatus, playerKind);
        return instance;
    }
}
