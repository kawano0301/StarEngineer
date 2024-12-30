using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Game.Player.Status;
using UnityEngine.InputSystem;

namespace Game.Player
{

    public class Player : MonoBehaviour
    {
        PlayerStatus m_baseStatus;

        PlayerStatus.PlanetKind m_planetNumber;
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;

        Vector2 m_velocity;

        //�f���ԍ�
        PlayerKind m_player;
        public enum PlayerKind
        {
            NoPlayer,
            Player1,
            Player2
        }

        //��ʊO�͈͂Ɣ��˗�
        const float SCREEN_WIDTH = 8.60f;
        const float SCREEN_HEIGHT = 4.70f;
        const float REBOUND_POWER = 20.0f;


        public void Initialize(PlayerStatus playerStatus, PlayerKind player)
        {
            m_player = player;
            m_baseStatus = playerStatus;
            m_hp = playerStatus.m_hp;
            m_speedScale = playerStatus.m_speedScale;
            m_attackScale = playerStatus.m_attackScale;

            m_planetNumber = playerStatus.m_planet;
            GetComponent<SpriteRenderer>().sprite = playerStatus.m_sprite;
            GetComponent<CircleCollider2D>().radius = playerStatus.m_collisionRadius;
        }


        void Update()
        {
            switch (m_player)
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

            if(InputManager.m_player1Shoot1)
            {
                Debug.Log("1");
            }

            if (InputManager.m_player1Shoot2)
            {
                Debug.Log("2");
            }

        }

        void Player1Update()
        {
            SetMovePower(InputManager.m_player1Input);
            MoveUpdate();
            BoundOverScreen();
        }

        void Player2Update()
        {
            SetMovePower(InputManager.m_player2Input);
            MoveUpdate();
            BoundOverScreen();
        }

        /// <summary>
        /// �ړ��l�Z�b�g
        /// </summary>
        /// <param name="movePower">�ړ��l</param>
        public void SetMovePower(Vector2 movePower)
        {
            //����̊m�F
            if (Mathf.Abs(m_velocity.x) > m_baseStatus.m_maxSpeed) return;
            if (Mathf.Abs(m_velocity.y) > m_baseStatus.m_maxSpeed) return;

            m_velocity += movePower;
        }

        /// <summary>
        /// �ړ��v�Z
        /// </summary>
        void MoveUpdate()
        {
            //�ړ��v�Z
            transform.position += (Vector3)m_velocity * m_baseStatus.m_speedScale * Time.deltaTime;

            //���x����
            m_velocity = m_velocity * 0.90f;
        }

        /// <summary>
        /// ��ʂɒ��˕Ԃ��ړ�����
        /// </summary>
        void BoundOverScreen()
        {
            //�E
            if (SCREEN_WIDTH < transform.position.x) { m_velocity.x = -REBOUND_POWER; }
            //��
            if (SCREEN_HEIGHT < transform.position.y) { m_velocity.y = -REBOUND_POWER; }
            //��
            if (transform.position.x < -SCREEN_WIDTH) { m_velocity.x = REBOUND_POWER; }
            //��
            if (transform.position.y < -SCREEN_HEIGHT) { m_velocity.y = REBOUND_POWER; }
        }


        void Attack1()
        {

        }

        void Attack2()
        {

        }

        //�_���[�W�Z�b�g
        public void SetDamage(int damageValue) { m_baseStatus.m_hp -= damageValue; }


        int GetHP() { return m_baseStatus.m_hp; }

    }
}