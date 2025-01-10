using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManage : MonoBehaviour
{

    float m_gameTimer = 0f;


    void Start()
    {
        
    }


    void Update()
    {
        m_gameTimer -= Time.deltaTime;
    }
}
