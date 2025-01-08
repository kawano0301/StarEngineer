using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorGradation : MonoBehaviour
{
    Image m_image;
    [SerializeField] int m_alphaStart;
    [SerializeField] int m_alphaEnd;
    [SerializeField] int m_anglePower;

    float m_angle;
    int m_alphaBetween;

    void Start()
    {
        m_image = GetComponent<Image>();
       Color color = m_image.color;
        color.a = m_alphaStart;
        m_image.color = color;
        m_alphaBetween = m_alphaEnd - m_alphaStart;
    }

    void Update()
    {
        m_angle += m_anglePower * Time.deltaTime;
        float work = Mathf.Sin(m_angle);

        Color color = m_image.color;
        color.a =( m_alphaStart + (Mathf.Abs(work) * m_alphaBetween)) / 255;
        m_image.color = color;
    }
}
