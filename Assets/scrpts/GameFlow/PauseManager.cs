using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
    }
}
