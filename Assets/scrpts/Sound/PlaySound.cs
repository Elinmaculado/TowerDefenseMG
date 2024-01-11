using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaySound : MonoBehaviour
{
    public List<AudioClip> soundBank;
    public AudioSource audioSource;

    public void PlaySoundOnce()
    {
        int randomIndex = Random.Range(0, soundBank.Count);
        audioSource.PlayOneShot(soundBank[randomIndex]);
    }
}
