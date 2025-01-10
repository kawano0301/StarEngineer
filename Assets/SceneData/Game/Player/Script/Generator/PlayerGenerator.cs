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
        Player playerObject1 = InstancePlayer(Player.PlayerKind.Player1
                                            , m_playerScript.s_player[0]
                                            , m_player1Pos).GetComponent<Player>();

        Player playerObject2 = InstancePlayer(Player.PlayerKind.Player2
                                            , m_playerScript.s_player[0]
                                            , m_player2Pos).GetComponent<Player>();

        playerObject1.SetEnemyPlayer(playerObject2);
        playerObject2.SetEnemyPlayer(playerObject1);

    }


    /// <summary>
    /// プレイヤーを生成する
    /// </summary>
    /// <param name="playerKind">操作するプレイヤー</param>
    /// <param name="playerStatus">武器装備</param>
    /// <param name="instancePosition">初期位置</param>
    /// <returns></returns>
    GameObject InstancePlayer(Player.PlayerKind playerKind, PlayerStatus playerStatus, Vector3 instancePosition)
    {
        GameObject instance = Instantiate(m_player, instancePosition, Quaternion.identity);
        instance.GetComponent<Player>().Initialize(playerKind, playerStatus);
        return instance;
    }
}
