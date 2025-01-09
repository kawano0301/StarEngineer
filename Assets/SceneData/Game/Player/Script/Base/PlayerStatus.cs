using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.Status
{

    [Serializable]
    public class PlayerStatus
    {

        public enum PlanetKind
        {
            MERCURY,//����
            VENUS,//����
            EARTH,//�n��
            MARS,//�ΐ�
            JUPITER,//�ؐ�
            SATUM,//�y��
            URANUS,//�V����
            NEPTUNE,//�C����
            PLUTO,//������
        }

        public int m_maxHP;
        public int m_hp;
        public float m_maxSpeed;
        public float m_speedScale;
        public float m_attackScale;
        public PlanetKind m_planet;
        public Sprite m_playerSprite;
        public Sprite m_iconSprite;
        public float m_collisionRadius;

    }
}
