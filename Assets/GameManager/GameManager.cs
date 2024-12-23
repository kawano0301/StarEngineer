using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip m_soundBGM;
    SoundManager m_soundManager;
    static GameObject m_gameManager;
    static GameObject m_inputPrefab;
    static GameObject m_soundManage;

    const string INPUT_OBJECT_NAME = "InputParent";
    const string SOUND_OBJECT_NAME = "SoundManage";
    const string GAME_MANAGER_OBJECT = "GameManager";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void PlayStart()
    {
        GameObject gameobject = Resources.Load(INPUT_OBJECT_NAME) as GameObject;
        m_gameManager = Instantiate(gameobject);
        gameobject.name = GAME_MANAGER_OBJECT;

        m_inputPrefab = Resources.Load(INPUT_OBJECT_NAME) as GameObject;
        m_soundManage = Resources.Load(SOUND_OBJECT_NAME) as GameObject;

        m_inputPrefab = Instantiate(m_inputPrefab);
        m_soundManage = Instantiate(m_soundManage);
    }

    private void Start()
    {
       SoundManager sound = m_soundManage.GetComponent<SoundManager>();
        sound.SetAndPlayBGM(m_soundBGM);
    }
}
