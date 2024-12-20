using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    int m_hp;
    const float SPEED = 1f;
    const float MAX_SPEED = 3f;

    Vector2 m_velocity;

    const float SCREEN_WIDTH = 8.60f;
    const float SCREEN_HEIGHT = 4.70f;

    void Start()
    {

    }


    void Update()
    {
        MoveUpdate();
        ScreenOutCheck();
    }



    int GetHP()
    {
        return m_hp;
    }

    void Damage(int damageValue)
    {
        m_hp -= damageValue;
    }

    void MoveUpdate()
    {
        //ˆÚ“®ŒvŽZ
        transform.position += (Vector3)m_velocity * SPEED * Time.deltaTime;

        //‘¬“xŒ¸Š
        m_velocity = m_velocity * 0.90f;
    }

    public void SetMovePower(Vector2 movePower)
    {
        if (Mathf.Abs(m_velocity.x) > MAX_SPEED) return;
        if (Mathf.Abs(m_velocity.y) > MAX_SPEED) return;

        m_velocity += movePower;
    }

    void ScreenOutCheck()
    {
        if (SCREEN_WIDTH < transform.position.x)
        {
            m_velocity.x = -10f;
        }
        if (SCREEN_HEIGHT < transform.position.y)
        {
            m_velocity.y = -10f;
        }
        if (transform.position.x < -SCREEN_WIDTH)
        {
            m_velocity.x = 10f;
        }
        if (transform.position.y < -SCREEN_HEIGHT)
        {
            m_velocity.y = 10f;
        }
    }

}
