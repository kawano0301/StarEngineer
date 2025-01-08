using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class ModeSelectManager : MonoBehaviour
{
    [SerializeField]
    RectTransform[] m_buttonTransforms;
    [SerializeField] RectTransform m_selectIcon;
    [SerializeField] WindowManager m_window;

    private void Start()
    {
        m_window = GameObject.Find("Window").GetComponent<WindowManager>();
    }

    public void OnStart()
    {
        if (m_window == null) LoadCostom();
        m_window.m_onClosed += LoadEquipmentSelect;
        m_window.CloseToOpenResetCallBack();
    }

    void LoadEquipmentSelect()
    {
        SceneManager.LoadScene("EquipmentSelect");
    }

    public void OnCustom()
    {
        if (m_window == null) LoadCostom();
        m_window.m_onClosed += LoadCostom;
        m_window.CloseToOpenResetCallBack();
    }

    void LoadCostom()
    {
        SceneManager.LoadScene("Custom");
    }

    public void OnExplanation()
    {
        SceneManager.LoadScene("PlayExplanation");
    }

    private void Update()
    {
        
    }

    public void Select(int index)
    {
        m_selectIcon.gameObject.SetActive(true);

        switch (index)
        {
            case 0:
                m_selectIcon.anchoredPosition = m_buttonTransforms[0].anchoredPosition;
                break;
            case 1:
                m_selectIcon.anchoredPosition = m_buttonTransforms[1].anchoredPosition;
                break;
            case 2:
                m_selectIcon.anchoredPosition = m_buttonTransforms[2].anchoredPosition;
                break;
            default:
                m_selectIcon.gameObject.SetActive(false);
                break;
                
        }
    }
}
