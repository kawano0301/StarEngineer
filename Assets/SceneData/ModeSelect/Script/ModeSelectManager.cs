using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ModeSelectManager : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("EquipmentSelect");
    }

    public void OnCustom()
    {
        SceneManager.LoadScene("Custom");
    }

    public void OnExplanation()
    {
        SceneManager.LoadScene("Custom");
    }
}
