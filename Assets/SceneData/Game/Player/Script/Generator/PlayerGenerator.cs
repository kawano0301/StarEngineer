using Game.Player;
using Game.Player.Status;
using Game.Weapon;
using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] CustomData m_customData;
    [SerializeField] WeaponScriptable m_weaponScriptable;
    [SerializeField] PlayerScriptable m_playerScriptable;
    [SerializeField] GameObject m_player;

    Vector3 m_player1Pos = new Vector3(-1, 0, 0);
    Vector3 m_player2Pos = new Vector3(1, 0, 0);


    void Start()
    {
        Player playerObject1 = InstancePlayer(Player.PlayerKind.Player1
                                            , m_player1Pos).GetComponent<Player>();

        Player playerObject2 = InstancePlayer(Player.PlayerKind.Player2
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
    GameObject InstancePlayer(Player.PlayerKind playerKind, Vector3 instancePosition)
    {
        PlanetEquipmentData planetData = m_customData.m_customData[1];

        GameObject instance = Instantiate(m_player, instancePosition, Quaternion.identity);

        WeaponStatus weaponStatus1 = m_weaponScriptable.GetWeaponStatus(planetData.st_weaponId1);
        WeaponStatus weaponStatus2 = m_weaponScriptable.GetWeaponStatus(planetData.st_weaponId2);

        WeaponBase weapon1 = Instantiate(weaponStatus1.s_weaponPrefab, instancePosition, Quaternion.identity, instance.transform).GetComponent<WeaponBase>();
        WeaponBase weapon2 = Instantiate(weaponStatus2.s_weaponPrefab, instancePosition, Quaternion.identity, instance.transform).GetComponent<WeaponBase>();

        PlayerStatus playerStatus = m_playerScriptable.s_player[planetData.st_planetKind];

        instance.GetComponent<Player>().Initialize(playerKind, playerStatus, weapon1, weapon2);

        return instance;
    }
}
