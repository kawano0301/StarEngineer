using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 m_moveDirection;
    float m_movePower = 0.02f;

    Player m_player;


    void Start()
    {
        m_player = GetComponent<Player>();
    }


    void Update()
    {
        InputMove();
        InputAttack();
        m_player.SetMovePower(m_moveDirection.normalized * 0.5f);


    }

    void InputMove()
    {
        //îÒì¸óÕ & ìØéûâüÇµÇÃèÍçáelse
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
            {
                m_moveDirection.y = Vector2.up.y;
            }

            if (Input.GetKey(KeyCode.S))
            {
                m_moveDirection.y = Vector2.down.y;
            }
        }
        else
        {
            m_moveDirection.y = 0;
        }

        if (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                m_moveDirection.x = Vector2.right.x;
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_moveDirection.x = Vector2.left.x;
            }
        }
        else
        {
            m_moveDirection.x = 0;
        }
    }

    void InputAttack()
    {

        if (Input.GetKey(KeyCode.R))
        {

        }

        if (Input.GetKey(KeyCode.F))
        {

        }

        if (Input.GetKey(KeyCode.E))
        {

        }
    }
}
