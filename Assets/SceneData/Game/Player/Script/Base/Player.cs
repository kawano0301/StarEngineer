using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Game.Player.Status;
using UnityEngine.InputSystem;
using Game.Weapon;

namespace Game.Player
{

    public class Player : MonoBehaviour
    {
        PlayerStatus m_baseStatus;

        //移動量
        Vector2 m_velocity;

        //相手の情報
        Player m_enemyPlayer;

        //プレイヤー番号
        PlayerKind m_playerKind;
        public enum PlayerKind
        {
            NoPlayer,
            Player1,
            Player2
        }

        //武器データ
        WeaponBase m_attack1;
        WeaponBase m_attack2;

        //画面外範囲と反射力
        const float SCREEN_WIDTH = 8.60f;
        const float SCREEN_HEIGHT = 4.70f;
        const float REBOUND_POWER = 16.0f;

        //ステータス
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;


        public void Initialize(PlayerKind playerKind, PlayerStatus playerStatus, WeaponBase attack1,WeaponBase attack2)
        {
            m_playerKind = playerKind;
            m_baseStatus = playerStatus;
            m_hp = playerStatus.m_hp;
            m_speedScale = playerStatus.m_speedScale;
            m_attackScale = playerStatus.m_attackScale;

            m_attack1 = attack1;
            m_attack2 = attack2;

            GetComponent<SpriteRenderer>().sprite = playerStatus.m_playerSprite;
            GetComponent<CircleCollider2D>().radius = playerStatus.m_collisionRadius;
        }

        public void SetEnemyPlayer(Player enemyPlayer) { m_enemyPlayer = enemyPlayer; }


        void Update()
        {
            switch (m_playerKind)
            {
                case PlayerKind.NoPlayer:
                    Debug.LogError("NoControlPlayer");
                    break;
                case PlayerKind.Player1:
                    Player1Update();
                    break;
                case PlayerKind.Player2:
                    Player2Update();
                    break;
            }

        }

        void Player1Update()
        {
            SetMovePower(InputManager.m_player1Input);
            MoveUpdate();
            BoundOverScreen();

            if (InputManager.m_player1Shoot1) { m_attack1.Shoot(); }

            if (InputManager.m_player1Shoot2) { m_attack2.Shoot(); }


            BoundPlayer((Vector2)m_enemyPlayer.transform.position);

        }

        void Player2Update()
        {
            SetMovePower(InputManager.m_player2Input);
            MoveUpdate();
            BoundOverScreen();

            if (InputManager.m_player2Shoot1) { m_attack1.Shoot(); }

            if (InputManager.m_player2Shoot2) { m_attack2.Shoot(); }
        }

        /// <summary>
        /// 移動値セット
        /// </summary>
        /// <param name="movePower">移動値</param>
        public void SetMovePower(Vector2 movePower)
        {
            //上限の確認
            if (Mathf.Abs(m_velocity.x) > m_baseStatus.m_maxSpeed) return;
            if (Mathf.Abs(m_velocity.y) > m_baseStatus.m_maxSpeed) return;

            m_velocity += movePower;
        }

        /// <summary>
        /// 移動計算
        /// </summary>
        void MoveUpdate()
        {
            //移動計算
            transform.position += (Vector3)m_velocity * m_baseStatus.m_speedScale * Time.deltaTime;

            //速度減衰
            m_velocity = m_velocity * 0.90f;
        }

        /// <summary>
        /// 画面に跳ね返す移動動作
        /// </summary>
        void BoundOverScreen()
        {
            //右
            if (SCREEN_WIDTH < transform.position.x) { m_velocity.x = -REBOUND_POWER; }
            //上
            if (SCREEN_HEIGHT < transform.position.y) { m_velocity.y = -REBOUND_POWER; }
            //左
            if (transform.position.x < -SCREEN_WIDTH) { m_velocity.x = REBOUND_POWER; }
            //下
            if (transform.position.y < -SCREEN_HEIGHT) { m_velocity.y = REBOUND_POWER; }
        }


        void BoundPlayer(Vector2 toPlayer)
        {
            Vector2 length = (Vector2)transform.position - toPlayer;

            m_velocity += length * REBOUND_POWER; 
        }


        //ダメージセット
        public void SetDamage(int damageValue)
        {
            m_enemyPlayer.m_hp -= damageValue;
        }

        int GetHP() { return m_baseStatus.m_hp; }

    }
}
