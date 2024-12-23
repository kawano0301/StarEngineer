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
    const string GAME_MANAGER_OBJECT = "GameManage";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void PlayStart()
    {
        GameObject gameobject = Resources.Load(GAME_MANAGER_OBJECT) as GameObject;
        m_gameManager = Instantiate(gameobject);
        gameobject.name = GAME_MANAGER_OBJECT;

        GameObject game = Resources.Load(INPUT_OBJECT_NAME) as GameObject;
        GameObject game2 = Resources.Load(SOUND_OBJECT_NAME) as GameObject;

        m_inputPrefab = Instantiate(game);
        m_soundManage = Instantiate(game2);
    }

    private void Start()
    {
       SoundManager sound = m_soundManage.GetComponent<SoundManager>();
        sound.SetAndPlayBGM(m_soundBGM);
    }
}
