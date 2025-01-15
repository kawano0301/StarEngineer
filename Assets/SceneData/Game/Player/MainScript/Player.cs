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

        bool m_bAlibe = false;

        //移動量
        Vector2 m_velocity;
        float m_speedDecay;

        //画面外範囲と反射力
        const float CENTER_Y_POINT = -1.01f;
        const float SCREEN_WIDTH = 8.54f;
        const float SCREEN_HEIGHT = 3.60f;
        const float REBOUND_POWER = 16.0f;
        //敵プレイヤーとの衝突距離
        const float ENEMY_MIN_LENGHT = 0.7f;

        //ステータス
        HPView m_hpView;
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;

        //武器データ
        WeaponBase m_attack1;
        WeaponBase m_attack2;


        public void Initialize(PlayerKind playerKind
                             , PlayerStatus playerStatus
                             , HPView viewHP
                             , WeaponBase attack1
                             , WeaponBase attack2)
        {
            m_playerKind = playerKind;
            m_baseStatus = playerStatus;
            m_hp = playerStatus.m_hp;
            m_speedScale = playerStatus.m_speedScale;
            m_speedDecay = playerStatus.m_speedDecay;
            m_attackScale = playerStatus.m_attackScale;

            m_hpView = viewHP;

            m_attack1 = attack1;
            m_attack2 = attack2;

            GetComponent<SpriteRenderer>().sprite = playerStatus.m_playerSprite;
            GetComponent<CircleCollider2D>().radius = playerStatus.m_collisionRadius;

            m_bAlibe = true;
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
            BoundPlayer((Vector2)m_enemyPlayer.transform.position
                       , ENEMY_MIN_LENGHT);

            if (InputManager.m_player1Shoot1) { m_attack1.Shoot(); }

            if (InputManager.m_player1Shoot2) { m_attack2.Shoot(); }


        }

        void Player2Update()
        {
            SetMovePower(InputManager.m_player2Input);
            MoveUpdate();

            BoundOverScreen();
            BoundPlayer((Vector2)m_enemyPlayer.transform.position
                       , ENEMY_MIN_LENGHT);

            if (InputManager.m_player2Shoot1) { m_attack1.Shoot(); }

            if (InputManager.m_player2Shoot2) { m_attack2.Shoot(); }


        }

        /// <summary>
        /// 移動方向と量を計算
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
        /// 移動の適応と速度減衰
        /// </summary>
        void MoveUpdate()
        {
            //移動適応
            transform.position += (Vector3)m_velocity * m_baseStatus.m_speedScale * Time.deltaTime;

            //速度減衰
            m_velocity = m_velocity * m_speedDecay;
        }

        /// <summary>
        /// 画面内に跳ね返す反射動作
        /// </summary>
        void BoundOverScreen()
        {
            //右
            if (SCREEN_WIDTH < transform.position.x) { m_velocity.x = -REBOUND_POWER; }
            //上
            if (CENTER_Y_POINT + SCREEN_HEIGHT < transform.position.y) { m_velocity.y = -REBOUND_POWER; }
            //左
            if (transform.position.x < -SCREEN_WIDTH) { m_velocity.x = REBOUND_POWER; }
            //下
            if (transform.position.y < CENTER_Y_POINT + -SCREEN_HEIGHT) { m_velocity.y = REBOUND_POWER; }
        }

        /// <summary>
        /// 対象と衝突した際の反射動作
        /// </summary>
        /// <param name="toPlayer"></param>
        /// <param name="collisionLength">当たり判定の距離</param>
         public void BoundPlayer(Vector2 toPlayer, float collisionLength)
        {
            Vector2 length = (Vector2)transform.position - toPlayer;

            //相手との距離の計算(トリガー)
            if (collisionLength > length.magnitude)
            {
                m_velocity += length * REBOUND_POWER;
            }
        }

        public void SetDamage(PlayerKind playerKind, int damageValue)
        {
            switch (playerKind)
            {
                case PlayerKind.NoPlayer:
                    Debug.LogError("NotFoundPlayer");
                    break;

                case PlayerKind.Player1:
                    m_hp -= damageValue;

                    if (m_hp <= 0) { m_bAlibe = false; }
                    break;

                case PlayerKind.Player2:
                    m_enemyPlayer.m_hp -= damageValue;

                    if (m_hp <= 0) { m_enemyPlayer.m_bAlibe = false; }
                    break;

            }
        }

        int GetHP() { return m_baseStatus.m_hp; }

    }
}
