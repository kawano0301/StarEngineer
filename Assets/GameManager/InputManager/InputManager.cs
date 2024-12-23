using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static bool m_rightButton;
    public static bool m_leftButton;
    public static bool m_upButton;
    public static bool m_downButton;
    public static bool m_rightButtonDown;
    public static bool m_leftButtonDown;
    public static bool m_upButtonDown;
    public static bool m_downButtonDown;
    public bool m_rightButtonDownLock;
    public bool m_leftButtonDownLock;
    public bool m_upButtonDownLock;
    public bool m_downButtonDownLock;

    public static bool m_player1Shoot1;
    public static bool m_player1Shoot2;
    public static bool m_player1ModeChange;
    public static bool m_player1Menu;

    public static bool m_rightButton2;
    public static bool m_leftButton2;
    public static bool m_upButton2;
    public static bool m_downButton2;
    public static bool m_rightButtonDown2;
    public static bool m_leftButtonDown2;
    public static bool m_upButtonDown2;
    public static bool m_downButtonDown2;
    public bool m_rightButtonDownLock2;
    public bool m_leftButtonDownLock2;
    public bool m_upButtonDownLock2;
    public bool m_downButtonDownLock2;

    public static bool m_player2Shoot1;
    public static bool m_player2Shoot2;
    public static bool m_player2ModeChange;
    public static bool m_player2Menu;

    public static Vector2 m_player1Input { get; private set; }
   
    public static Vector2 m_player2Input { get; private set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject.transform.parent.gameObject);
    }

    void Update()
    {
        /* Player1 */
        if (Input.GetKey(KeyCode.W))
        {
            m_upButton = true;
            if (!m_upButtonDownLock)
            {
                m_upButtonDown = true;
                m_upButtonDownLock = true;
            }
            else
            {
                m_upButtonDown = false;
            }
        }
        else
        {
            m_upButton = false;
            m_upButtonDownLock = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_rightButton = true;
            if (!m_rightButtonDownLock)
            {
                m_rightButtonDown = true;
                m_rightButtonDownLock = true;
            }
            else
            {
                m_rightButtonDown = false;
            }
        }
        else
        {
            m_rightButton = false;
            m_rightButtonDownLock = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_downButton = true;
            if (!m_downButtonDownLock)
            {
                m_downButtonDown = true;
                m_downButtonDownLock = true;
            }
            else
            {
                m_downButtonDown = false;
            }
        }
        else
        {
            m_downButton = false;
            m_downButtonDownLock = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_leftButton = true;
            if (!m_leftButtonDownLock)
            {
                m_leftButtonDown = true;
                m_leftButtonDownLock = true;
            }
            else
            {
                m_leftButtonDown = false;
            }
        }
        else
        {
            m_leftButton = false;
            m_leftButtonDownLock = false;
        }

        /* Player2 */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_upButton2 = true;
            if (!m_upButtonDownLock2)
            {
                m_upButtonDown2 = true;
                m_upButtonDownLock2 = true;
            }
            else
            {
                m_upButtonDown2 = false;
            }
        }
        else
        {
            m_upButton2 = false;
            m_upButtonDownLock2 = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rightButton2 = true;
            if (!m_rightButtonDownLock2)
            {
                m_rightButtonDown2 = true;
                m_rightButtonDownLock2 = true;
            }
            else
            {
                m_rightButtonDown2 = false;
            }
        }
        else
        {
            m_rightButton2 = false;
            m_rightButtonDownLock2 = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_downButton2 = true;
            if (!m_downButtonDownLock2)
            {
                m_downButtonDown2 = true;
                m_downButtonDownLock2 = true;
            }
            else
            {
                m_downButtonDown2 = false;
            }
        }
        else
        {
            m_downButton2 = false;
            m_downButtonDownLock2 = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_leftButton2 = true;
            if (!m_leftButtonDownLock2)
            {
                m_leftButtonDown2 = true;
                m_leftButtonDownLock2 = true;
            }
            else
            {
                m_leftButtonDown2 = false;
            }
        }
        else
        {
            m_leftButton2 = false;
            m_leftButtonDownLock2 = false;
        }

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        m_player1Input = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        m_player1Shoot1 = context.started;
        if(context.canceled)
        {
            m_player1Shoot1 = false;
        }
    }
    public void OnFire2(InputAction.CallbackContext context)
    {
        m_player1Shoot2 = context.started;
        if (context.canceled)
        {
            m_player1Shoot2 = false;
        }
    }

    public void OnModeChange(InputAction.CallbackContext context)
    {
        m_player1ModeChange = context.started;
        if(context.canceled)
        {
            m_player1ModeChange = false;
        }
    }

    public void OnPlayer2Move(InputAction.CallbackContext context)
    {
        m_player2Input = context.ReadValue<Vector2>();
    }

    public void OnPlayer2Fire(InputAction.CallbackContext context)
    {
        m_player2Shoot1 = context.started;
        if (context.canceled)
        {
            m_player2Shoot1 = false;
        }
    }
    public void OnPlayer2Fire2(InputAction.CallbackContext context)
    {
        m_player2Shoot2 = context.started;
        if (context.canceled)
        {
            m_player2Shoot2 = false;
        }
    }

    public void OnPlayer2ModeChange(InputAction.CallbackContext context)
    {
        m_player2ModeChange = context.started;
        if (context.canceled)
        {
            m_player2ModeChange = false;
        }
    }

}
