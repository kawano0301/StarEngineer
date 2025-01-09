using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomEquipmentManager : MonoBehaviour
{

    [SerializeField] RectTransform m_customSelectIcon;
    [SerializeField] RectTransform[] m_customSelects;
    [SerializeField] Image[] m_nowEuipmentSprite;
    [SerializeField] CustomData m_customData;

    [SerializeField] GameObject m_planetIconParent;
    [SerializeField] GameObject m_weaponIconParent;
    [SerializeField] RectTransform m_selectIcon;
    [SerializeField]
    RectTransform[] m_equipmentSelects;
    PlanetEquipmentData m_nowEquipmentData;
    int m_customSelectIndex;

    int m_changeEqipmentIndex;

    readonly int MOVE_POWER = 25;
    readonly Vector3 TRANSFROM_DEFAULT = new Vector3(-850, 350, 0);
    readonly Vector3 TRANSFOM_POSITION = new Vector3(-825, 350, 0);
    const float TRANSFORM_TIME = 0.1f;

    public enum ChangeKind
    {
        PLANET,
        WEAPON1,
        WEAPON2,
        BATTLE1,
        BATTLE2,
    }

    void Start()
    {
        m_nowEquipmentData = m_customData.m_customData[0];
        m_planetIconParent.SetActive(false);
        m_weaponIconParent.SetActive(false);
    }

    public void SelectMotion(int index)
    {
        for (int i = 0; i < m_customSelects.Length; i++)
        {
            Vector3 work = TRANSFROM_DEFAULT;
            work.y = m_customSelects[i].localPosition.y;
            m_customSelects[i].DOLocalMove(work, TRANSFORM_TIME);
        }
        if (m_customSelects.Length > index)
        {
            Vector3 work = TRANSFOM_POSITION;
            work.y = m_customSelects[index].localPosition.y;
            m_customSelects[index].DOLocalMove(work, TRANSFORM_TIME);
        }
    }

    public void CustomSelect(int index)
    {
        m_customSelectIcon.anchoredPosition = m_customSelects[index].anchoredPosition;
        m_customSelectIcon.SetParent(m_customSelects[index],true);
        m_customSelectIcon.anchoredPosition = Vector2.zero;
        m_customSelectIndex = index;
        CustomDrawUpdate();
    }

    void CustomDrawUpdate()
    {
        m_nowEquipmentData = m_customData.m_customData[m_customSelectIndex];
        SetPlanetKind(m_nowEquipmentData.st_planetKind);
        SetWeapon1Kind(m_nowEquipmentData.st_weaponId1);
        SetWeapon2Kind(m_nowEquipmentData.st_weaponId2);
        SetAuto1Kind(m_nowEquipmentData.st_autoId1);
        SetAuto2Kind(m_nowEquipmentData.st_autoId2);
    }

    public void OnChangeData(int index)
    {
        if(index > m_equipmentSelects.Length)
        {
            m_selectIcon.gameObject.SetActive(false);
        }
        m_selectIcon.gameObject.SetActive(true);
       m_selectIcon.anchoredPosition  = m_equipmentSelects[index].anchoredPosition;
    }

    public void ChangeData(int index)
    {
        switch ((ChangeKind)index)
        {
            case ChangeKind.PLANET:
                m_planetIconParent.SetActive(true);
                m_weaponIconParent.SetActive(false);
                break;
            case ChangeKind.WEAPON1:
                m_planetIconParent.SetActive(false);
                m_weaponIconParent.SetActive(true);
                break;
            case ChangeKind.WEAPON2:
                m_planetIconParent.SetActive(false);
                m_weaponIconParent.SetActive(true);
                break;
            case ChangeKind.BATTLE1:
                m_planetIconParent.SetActive(false);
                m_weaponIconParent.SetActive(true);
                break;
            case ChangeKind.BATTLE2:
                m_planetIconParent.SetActive(false);
                m_weaponIconParent.SetActive(true);
                break;
            default:
                break;
        }

    }

    public void ApplyId()
    {
        
    }

    public void SetPlanetKind(int kind)
    {
        m_nowEquipmentData.st_planetKind = kind;
    }

    public void SetWeapon1Kind(int kind)
    {
        m_nowEquipmentData.st_weaponId1 = kind;
    }
    public void SetWeapon2Kind(int kind)
    {
        m_nowEquipmentData.st_weaponId2 = kind;
    }
    public void SetAuto1Kind(int kind)
    {
        m_nowEquipmentData.st_autoId1 = kind;
    }
    public void SetAuto2Kind(int kind)
    {
        m_nowEquipmentData.st_autoId2 = kind;
    }
}
