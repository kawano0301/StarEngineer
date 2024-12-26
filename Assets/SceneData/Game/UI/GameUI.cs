using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUI : MonoBehaviour
    {
        //[SerializeField] UIScriptable;
        Sprite[] m_timerSprite;
        Image m_timerLeft;
        Image m_timerRight;

        float m_gameTimer;//Scriptable‚Åˆµ‚¤’l‚ðŠî‚É‚·‚é

        void Start()
        {
            m_gameTimer = 99;
        }


        void Update()
        {
            m_gameTimer -= Time.deltaTime;
            TimerSpriteUpdate(m_gameTimer);
        }

        void TimerSpriteUpdate(float timer)
        {
            //m_timerLeft.sprite = m_timerSprite[];
            //m_timerRight.sprite = m_timerSprite[];

        }
/*
        int OneDigit(float timer)
        {
            return;
        }
        int TwoDigit(float timer)
        {
            return;
        }
*/
    }
}