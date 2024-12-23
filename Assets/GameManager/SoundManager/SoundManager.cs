using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource m_bgmAudioSource;
    [SerializeField] AudioSource m_seAudioSource;
    static AudioSource m_staticSeAudioSource;
    bool m_onFade;
    float m_fadeTimer;
    float m_fadeTime;
    float m_audioPower;
    float m_fadePower;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_staticSeAudioSource = m_seAudioSource;
    }

    private void Update()
    {
        if(m_onFade)
        {
            m_fadeTimer += Time.deltaTime;
            if(m_fadeTimer > m_fadeTime)
            {
                m_fadeTimer = 0f;
                m_bgmAudioSource.volume -= m_fadePower;
                if(m_bgmAudioSource.volume <= 0f)m_bgmAudioSource.volume = 0f;
                m_onFade = false;
            }
        }
    }

    public void SetAndPlayBGM(AudioClip audioClip)
    {
        m_bgmAudioSource.clip = audioClip;
        m_bgmAudioSource.Play();
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    /// <param name="fadeTime">フェードアウトする時間　0で即終了</param>
    public void StopBGM(float fadeTime = 0)
    {
        if(fadeTime == 0)
        {
            m_bgmAudioSource.volume = 0;
            return;
        }
        m_fadeTimer = fadeTime;
        m_onFade = true;
        m_fadePower = m_bgmAudioSource.volume / fadeTime;
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    static void PlaySE(AudioClip audioClip)
    {
        m_staticSeAudioSource.PlayOneShot(audioClip);
    }
}
