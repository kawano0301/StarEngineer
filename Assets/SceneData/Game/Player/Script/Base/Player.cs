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

        //�ړ���
        Vector2 m_velocity;

        //����̏��
        Player m_enemyPlayer;

        //�v���C���[�ԍ�
        PlayerKind m_playerKind;
        public enum PlayerKind
        {
            NoPlayer,
            Player1,
            Player2
        }

        //����f�[�^
        WeaponBase m_attack1;
        WeaponBase m_attack2;

        //��ʊO�͈͂Ɣ��˗�
        const float SCREEN_WIDTH = 8.60f;
        const float SCREEN_HEIGHT = 4.70f;
        const float REBOUND_POWER = 20.0f;

        //�X�e�[�^�X
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;


        public void Initialize(PlayerKind playerKind, PlayerStatus playerStatus)
        {
            m_playerKind = playerKind;
            m_baseStatus = playerStatus;
            m_hp = playerStatus.m_hp;
            m_speedScale = playerStatus.m_speedScale;
            m_attackScale = playerStatus.m_attackScale;

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

            if (InputManager.m_player1Shoot1) { Debug.Log("1"); }

            if (InputManager.m_player1Shoot2) { Debug.Log("2"); }
            SetDamage(1);


            Debug.Log(m_hp);
            Debug.Log(m_enemyPlayer.m_hp);
        }

        void Player2Update()
        {
            SetMovePower(InputManager.m_player2Input);
            MoveUpdate();
            BoundOverScreen();

            if (InputManager.m_player2Shoot1) { }

            if (InputManager.m_player2Shoot2) { }
            Debug.Log(m_hp);
            Debug.Log(m_enemyPlayer.m_hp);
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


        //�_���[�W�Z�b�g
        public void SetDamage(int damageValue)
        {
            m_enemyPlayer.m_hp -= damageValue;
        }


        int GetHP() { return m_baseStatus.m_hp; }

    }
}
