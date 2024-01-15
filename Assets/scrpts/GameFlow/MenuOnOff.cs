using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnOff : MonoBehaviour
{

    [SerializeField] private List<GameObject> on;
    [SerializeField] private List<GameObject> off;
    [SerializeField] private AudioClip pause;
    [SerializeField] private AudioClip unPause;    
    [SerializeField] private AudioClip fastSpeed;
    [SerializeField] private AudioClip slowSpeed;
    [SerializeField] private AudioSource audioSource;

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
        audioSource.PlayOneShot(pause);
        Time.timeScale = 0.0f;
    }

    public void UnPuause()
    {
        audioSource.PlayOneShot(unPause);
        Time.timeScale = 1.0f;
    }

    public void OnCanvasGroupChanged()
    {
        if(Time.timeScale != 1.0f)
        {
            audioSource.PlayOneShot(slowSpeed);
            Time.timeScale = 1.0f;
        }
        else
        {
            audioSource.PlayOneShot(fastSpeed);
            Time.timeScale = 2.0f;
        }
    }
}
