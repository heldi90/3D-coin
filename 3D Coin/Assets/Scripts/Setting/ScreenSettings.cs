using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SimpleInputNamespace;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    public bool active;

    public GameObject objActive;

    private void Start()
    {
        FullScreen(true);
    }

    public void PressButtonFullScreen()
    {
        switch (active && objActive.activeSelf)
        {
            case true:
                active = false;
                objActive.SetActive(false);
                Screen.SetResolution(800, 400, true);
                FullScreen(active);
                break;
            case false:
                active = true;
                objActive.SetActive(true);
                Screen.SetResolution(1920, 1080, true);
                FullScreen(active);
                break;
        }
    }
    public void FullScreen(bool isFullScreen) => Screen.fullScreen = isFullScreen;

}
