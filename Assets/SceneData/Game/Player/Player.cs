using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 m_velocity;
    int m_hp;
    float m_speed;



    void Start()
    {

    }


    void Update()
    {

    }



    int GetHP()
    {
        return m_hp;
    }

    void Damage(int damageValue)
    {
        m_hp -= damageValue;
    }



    void MoveUp()
    {
        m_velocity.y += m_speed;
        transform.position = m_velocity * Time.deltaTime;

    }

    void MoveRight()
    {
        m_velocity.x += m_speed;
        transform.position = m_velocity * Time.deltaTime;
    }

    void MoveDown()
    {
        m_velocity.y -= m_speed;
        transform.position = m_velocity * Time.deltaTime;
    }

    void MoveLeft()
    {
        m_velocity.x -= m_speed;
        transform.position = m_velocity * Time.deltaTime;
    }

    void WeaponAttack1()
    {

    }

    void WeaponAttack2()
    {

    }

    void WeaponChange()
    {

    }


}
