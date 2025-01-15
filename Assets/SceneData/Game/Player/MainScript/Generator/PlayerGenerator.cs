using Game.Player;
using Game.Player.Status;
using Game.Weapon;
using Game.Weapon.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] CustomData m_customDataList;
    [SerializeField] GameObject m_player;
    [SerializeField] PlanetDataBase m_planetScriptable;
    [SerializeField] WeaponScriptable m_weaponScriptable;

    Vector3 m_player1Pos = new Vector3(-1, 0, 0);
    Vector3 m_player2Pos = new Vector3(1, 0, 0);


    void Start()
    {
        Player playerObject1 = InstancePlayer(Player.PlayerKind.Player1
                                            , 2
                                            , m_player1Pos).GetComponent<Player>();

        Player playerObject2 = InstancePlayer(Player.PlayerKind.Player2
                                            , 3
                                            , m_player2Pos).GetComponent<Player>();

        playerObject1.SetEnemyPlayer(playerObject2);
        playerObject2.SetEnemyPlayer(playerObject1);

    }


    /// <summary>
    /// ÉvÉåÉCÉÑÅ[Çê∂ê¨Ç∑ÇÈ
    /// </summary>
    Transform InstancePlayer(Player.PlayerKind playerKind,int generalCustomData, Vector3 instancePosition)
    {
        Transform instance = Instantiate(m_player, instancePosition, Quaternion.identity).transform;

        PlanetEquipmentData customData = m_customDataList.m_customData[generalCustomData];

        GameObject weaponObject1 = m_weaponScriptable.GetWeaponStatus(customData.st_weaponId1).s_weaponPrefab;
        GameObject weaponObject2 = m_weaponScriptable.GetWeaponStatus(customData.st_weaponId2).s_weaponPrefab;

        WeaponBase weapon1 = Instantiate(weaponObject1, instancePosition, Quaternion.identity, instance).GetComponent<WeaponBase>();
        WeaponBase weapon2 = Instantiate(weaponObject2, instancePosition, Quaternion.identity, instance).GetComponent<WeaponBase>();

        PlayerStatus playerStatus = m_planetScriptable.s_playerStatus[customData.st_planetKind];

        instance.GetComponent<Player>().Initialize(playerKind, playerStatus, weapon1, weapon2);

        return instance;
    }
}
