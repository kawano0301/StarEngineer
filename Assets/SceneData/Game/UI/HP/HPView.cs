using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPView : MonoBehaviour
{

    Image m_redGaugeHP;
    Image m_greenGaugeHP;

    float m_playerHP;
    float m_redGauge;
    float m_decayRedGauge = 0.1f;
    int m_maxHP;

    private void Start()
    {
        m_redGaugeHP = transform.GetChild(1).GetComponent<Image>();
        m_greenGaugeHP = transform.GetChild(2).GetComponent<Image>();
    }

    void Initialize(float nowHP, int maxHP)
    {
        m_playerHP = nowHP;
        m_redGauge = nowHP;
        m_maxHP = maxHP;

        m_redGaugeHP.fillAmount = nowHP / maxHP;
        m_greenGaugeHP.fillAmount = nowHP / maxHP;
    }

    private void Update()
    {
        if (m_playerHP < m_redGauge)
        {
            m_redGauge -= m_decayRedGauge;
            m_redGaugeHP.fillAmount = m_redGauge / m_maxHP;
        }
    }


    public void HPViewControl(float nowHP)
    {
        m_playerHP = nowHP;
        m_greenGaugeHP.fillAmount = nowHP / m_maxHP;
    }   

}
