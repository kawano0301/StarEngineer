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

        bool m_bAlibe = false;

        //�ړ���
        Vector2 m_velocity;

        //��ʊO�͈͂Ɣ��˗�
        const float SCREEN_WIDTH = 8.60f;
        const float SCREEN_HEIGHT = 4.70f;
        const float REBOUND_POWER = 16.0f;
        //�G�v���C���[�Ƃ̏Փˋ���
        const float ENEMY_MIN_LENGHT = 0.7f;

        //�X�e�[�^�X
        int m_hp = 0;
        float m_speedScale = 1;
        float m_attackScale = 1;

        //����f�[�^
        WeaponBase m_attack1;
        WeaponBase m_attack2;


        public void Initialize(PlayerKind playerKind, PlayerStatus playerStatus, WeaponBase attack1, WeaponBase attack2)
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
        /// �ړ������Ɨʂ��v�Z
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
        /// �ړ��̓K���Ƒ��x����
        /// </summary>
        void MoveUpdate()
        {
            //�ړ��K��
            transform.position += (Vector3)m_velocity * m_baseStatus.m_speedScale * Time.deltaTime;

            //���x����
            m_velocity = m_velocity * 0.90f;
        }

        /// <summary>
        /// ��ʓ��ɒ��˕Ԃ����˓���
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

        /// <summary>
        /// �ΏۂƏՓ˂����ۂ̔��˓���
        /// </summary>
        /// <param name="toPlayer"></param>
        /// <param name="collisionLength">�����蔻��̋���</param>
         public void BoundPlayer(Vector2 toPlayer, float collisionLength)
        {
            //����Ƃ̋����̌v�Z(�g���K�[)
            if (0.7f > ((Vector2)transform.position - toPlayer).magnitude)
            {
                Vector2 length = (Vector2)transform.position - toPlayer;

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
                    break;
                case PlayerKind.Player2:
                    m_enemyPlayer.m_hp -= damageValue;
                    break;
            }
        }

        int GetHP() { return m_baseStatus.m_hp; }

    }
}