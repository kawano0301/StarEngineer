using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerViewControl : MonoBehaviour
{
    TextMeshProUGUI m_timerText;

    float m_timer = 10;

    private void Start()
    {
        m_timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;
        TimeCounterUpdate(m_timer);
    }

    /// <summary>
    /// �^�C�}�[�J�E���g�̍X�V
    /// </summary>
    /// <param name="timer"></param>
    public void TimeCounterUpdate(float timer)
    {
        //������100�ȏ�̏ꍇ�������Ȃ�(�^�C�}�[�̕\�L�������)
        if (timer >= 100) { Debug.LogError("OverTimer"); return; }

        //�^�C�}�[�I���㓮��
        if (timer < 0.00f)
        {
            return;
        }

        //�^�C�}�[�̌��ڂ��v�Z
        int twoDigits = (int)timer / 10;
        int oneDigits = (int)timer - twoDigits * 10;

        //�e�L�X�g�ɓ���(UI�^�C�}�[����)
        m_timerText.text = "<sprite=" + twoDigits + ">" +
                           "<sprite=" + oneDigits + ">";
    }
}
