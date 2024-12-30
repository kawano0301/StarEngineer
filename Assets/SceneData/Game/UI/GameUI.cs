using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUI : MonoBehaviour
    {
        float m_gameTimer;

        void Start()
        {
            m_gameTimer = 99;
        }


        void Update()
        {
            m_gameTimer -= Time.deltaTime;
        }

    }
}