using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Game.Player.Status;

namespace Game.Player
{

    public class Player : MonoBehaviour
    {
        PlayerKind m_player;
        public enum PlayerKind
        {
            NoPlayer,
            Player1,
            Player2
        }

        PlayerStatus m_baseStatus;

        PlayerStatus.PlanetKind m_planetNumber;
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;
        SpriteRenderer m_planetSprite;

        Vector2 m_velocity;


        const float SCREEN_WIDTH = 8.60f;
        const float SCREEN_HEIGHT = 4.70f;

        public void Initialize(PlayerStatus playerStatus, PlayerKind player)
        {
            m_player = player;
            m_baseStatus = playerStatus;
            m_planetNumber = playerStatus.m_planet;
            m_hp = playerStatus.m_hp;
            m_speedScale = playerStatus.m_speedScale;
            m_attackScale = playerStatus.m_attackScale;
            m_planetSprite = GetComponent<SpriteRenderer>();
            m_planetSprite.sprite = playerStatus.m_sprite;
            //GetComponent<CircleCollider2D>().radius = playerStatus.m_collisionRadius;
        }


        void Update()
        {
            switch (m_player)
            {
                case PlayerKind.NoPlayer:
                    Debug.LogError("adderror");
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
            ScreenOutCheck();
        }

        void Player2Update()
        {
            SetMovePower(InputManager.m_player2Input);
            MoveUpdate();
            ScreenOutCheck();
        }

        /// <summary>
        /// 移動値セット
        /// </summary>
        /// <param name="movePower">移動値</param>
        public void SetMovePower(Vector2 movePower)
        {
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
        /// 画面外移動時に戻す動作
        /// </summary>
        void ScreenOutCheck()
        {
            //右
            if (SCREEN_WIDTH < transform.position.x) { m_velocity.x = -10f; }
            //上
            if (SCREEN_HEIGHT < transform.position.y) { m_velocity.y = -10f; }
            //左
            if (transform.position.x < -SCREEN_WIDTH) { m_velocity.x = 10f; }
            //下
            if (transform.position.y < -SCREEN_HEIGHT) { m_velocity.y = 10f; }
        }

        //ダメージセット
        public void SetDamage(int damageValue) { m_baseStatus.m_hp -= damageValue; }


        int GetHP() { return m_baseStatus.m_hp; }

    }
}
