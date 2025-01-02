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
    /// タイマーカウントの更新
    /// </summary>
    /// <param name="timer"></param>
    public void TimeCounterUpdate(float timer)
    {
        //引数が100以上の場合処理しない(タイマーの表記が乱れる)
        if (timer >= 100) { Debug.LogError("OverTimer"); return; }

        //タイマー終了後動作
        if (timer < 0.00f)
        {
            return;
        }

        //タイマーの桁目を計算
        int twoDigits = (int)timer / 10;
        int oneDigits = (int)timer - twoDigits * 10;

        //テキストに導入(UIタイマー操作)
        m_timerText.text = "<sprite=" + twoDigits + ">" +
                           "<sprite=" + oneDigits + ">";
    }
}
