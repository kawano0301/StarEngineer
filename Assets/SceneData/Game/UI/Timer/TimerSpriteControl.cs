using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSpriteControl : MonoBehaviour
{
    TextMeshProUGUI m_timerText;

    float m_timer = 99;

    private void Start()
    {
        m_timerText = GetComponent<TextMeshProUGUI>();
        m_timerText.text = "<sprite=" + m_timer/10 + ">" + "<sprite=" + TimerConta(m_timer) + ">";
    }

    int TimerConta(float time)
    {
        int twoDigits = (int)time / 10;

        return (int)time - twoDigits * 10;
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;
        m_timerText.text = "<sprite=" + m_timer / 10 + ">" + "<sprite=" + TimerConta(m_timer) + ">";

    }

}
