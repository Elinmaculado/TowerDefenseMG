using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject losseScreen;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private AudioSource musicLevel;
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip losseMusic;
    [SerializeField] private List<AudioClip> losseSounds;
    bool isGameOver = false;

    public int totalOffEnemies;
    public Image fillImage;
    public float currentEnemies;


    

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 1.0f;
            musicLevel.Stop();
            LosseSound();
            levelMenu.SetActive(false);
            losseScreen.gameObject.SetActive(true);
        }
        
    }

    public void LevelCleared()
    {
        levelMenu.SetActive(false);
        musicLevel.Stop();
        WinSound();
        winScreen.gameObject.SetActive(true);
    }

    public void IsLevelCleared()
    {
        currentEnemies--;
        float fillValue = currentEnemies / totalOffEnemies;
        fillImage.fillAmount = fillValue;
        if(currentEnemies <= 0) 
        {
            LevelCleared();
        }
    }

    private void WinSound()
    {
        musicLevel.PlayOneShot(winSFX);
    }  
    private void LosseSound()
    {
        
        StartCoroutine(LosseSoundDelay(losseSounds[0], 0));
    }

    IEnumerator LosseSoundDelay(AudioClip clip, int i)
    {
        i++;
        effectsSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        if (i < losseSounds.Count)
        {
            StartCoroutine(LosseSoundDelay(losseSounds[i],i));    
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }

}
