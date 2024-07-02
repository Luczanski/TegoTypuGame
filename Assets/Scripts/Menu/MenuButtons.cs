using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MenuButtons : MonoBehaviour
{
    public float delayTime = 4f;
    public void GStart()
    {
        Invoke("PerformAction", delayTime);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void PerformAction()
    {
        SceneManager.LoadScene(1);
    }
}
