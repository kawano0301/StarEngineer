using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_rightWindow;
    [SerializeField]
    GameObject m_leftWindow;

    public delegate void OnWindowDoor();
    public OnWindowDoor m_onClosed;
    public OnWindowDoor m_onOpend;

    readonly Vector3 CLOSED_DOOR_RIGHT = new Vector3(-4.2f, 0, 0);
    readonly Vector3 CLOSED_DOOR_LEFT = new Vector3(-14.2f, 0, 0);
    readonly Vector3 OPEN_DOOR_RIGHT = new Vector3(6.4f, 0, 0);
    readonly Vector3 OPEN_DOOR_LEFT = new Vector3(-22.6f, 0, 0);
    const float CLOSED_TIME = 0.75f;
    const float OPEN_TIME = 0.75f;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CloseToOpen()
    {
        m_rightWindow.transform.DOLocalMove(CLOSED_DOOR_RIGHT, CLOSED_TIME);
        m_leftWindow.transform.DOLocalMove(CLOSED_DOOR_LEFT, CLOSED_TIME).OnComplete(() =>
        {
            if (m_onClosed != null)
            {
                m_onClosed();
            }
            m_rightWindow.transform.DOLocalMove(OPEN_DOOR_RIGHT, OPEN_TIME);
            m_leftWindow.transform.DOLocalMove(OPEN_DOOR_LEFT, OPEN_TIME);
        });
    }
    public void CloseToOpenResetCallBack()
    {
        m_rightWindow.transform.DOLocalMove(CLOSED_DOOR_RIGHT, CLOSED_TIME);
        m_leftWindow.transform.DOLocalMove(CLOSED_DOOR_LEFT, CLOSED_TIME).OnComplete(() =>
        {
            if (m_onClosed != null)
            {
                m_onClosed();
                m_onClosed = null;
            }
            m_rightWindow.transform.DOLocalMove(OPEN_DOOR_RIGHT, OPEN_TIME);
            m_leftWindow.transform.DOLocalMove(OPEN_DOOR_LEFT, OPEN_TIME);
        });
    }

    public void Close()
    {
        m_rightWindow.transform.DOLocalMove(CLOSED_DOOR_RIGHT, CLOSED_TIME);
        m_leftWindow.transform.DOLocalMove(CLOSED_DOOR_LEFT, CLOSED_TIME).OnComplete(() =>
        {
            if (m_onClosed != null)
            {
                m_onClosed();
            }
        });
    }

    public void Open()
    {
        m_rightWindow.transform.DOLocalMove(OPEN_DOOR_RIGHT, OPEN_TIME);
        m_leftWindow.transform.DOLocalMove(OPEN_DOOR_LEFT, OPEN_TIME).OnComplete(() =>
        {
            if (m_onOpend != null)
            {
                m_onOpend();
            }
        });
    }

}
