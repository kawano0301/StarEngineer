using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplanationManage : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Back();
        }
    }
}
