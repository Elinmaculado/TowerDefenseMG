using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnOff : MonoBehaviour
{

    [SerializeField] private List<GameObject> on;
    [SerializeField] private List<GameObject> off;


    public void OnOff()
    {
        for (int i = 0; i < off.Count; i++)
        {
            off[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < on.Count; i++)
        {
            on[i].gameObject.SetActive(true);
        }
        
    }

    public void Pause()
    {
        PauseSound.instance.PlayPause();
        Time.timeScale = 0.0f;
    }

    public void UnPuause()
    {
        PauseSound.instance.PlayUnpause();
        Time.timeScale = 1.0f;
    }

    public void ChangeSpeed()
    {
        if(Time.timeScale != 1.0f)
        {
            PauseSound.instance.PlaySlow();
            Time.timeScale = 1.0f;
        }
        else
        {
            PauseSound.instance.PlayFast();
            Time.timeScale = 2.0f;
        }
    }
}
