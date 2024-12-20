using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] WindowManager m_windowManager;
    [SerializeField] GameObject m_back;
    [SerializeField] TMP_Text m_text;
    
    AsyncOperation m_asyncOperation;

    private void Start()
    {
        DontDestroyOnLoad(m_back);
    }
    public void ToGameScene()
    {
        m_windowManager.CloseToOpen();
        m_asyncOperation = SceneManager.LoadSceneAsync("ModeSelect");
        m_asyncOperation.allowSceneActivation = false;
        m_windowManager.m_onClosed += ChangeScene;
    }

    void ChangeScene()
    {
        m_asyncOperation.allowSceneActivation = true;
    }

    public void OnEnterText()
    {
        m_text.fontStyle = FontStyles.Bold;
        m_text.fontStyle += (int)FontStyles.Underline;
    }

    public void EndEnterText()
    {
        m_text.fontStyle = FontStyles.Normal;
    }
}
