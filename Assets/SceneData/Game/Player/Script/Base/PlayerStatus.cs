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

        public PlanetKind m_planet;
        public int m_maxHP;
        public int m_hp;
        public float m_maxSpeed;
        public float m_speedScale;
        public float m_attackScale;
        public Sprite m_sprite;
        public float m_collisionRadius;

    }
}
