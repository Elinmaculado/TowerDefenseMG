using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSound : MonoBehaviour
{
    [SerializeField] private AudioClip pause;
    [SerializeField] private AudioClip unPause;
    [SerializeField] private AudioClip fastSpeed;
    [SerializeField] private AudioClip slowSpeed;
    [SerializeField] private AudioSource audioSource;

    public static PauseSound instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayPause()
    {
        audioSource.PlayOneShot(pause);
    }
    public void PlayUnpause()
    {
        audioSource.PlayOneShot(unPause);
    }
    public void PlaySlow()
    {
        audioSource.PlayOneShot(slowSpeed);
    }
    public void PlayFast()
    {
        audioSource.PlayOneShot(fastSpeed);
    }
         
        
         
}
