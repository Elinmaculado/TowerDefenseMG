using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject losseScreen;
    [SerializeField] private GameObject levelMenu;

    public int totalOffEnemies;

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
        Time.timeScale = 0.0f;
        levelMenu.SetActive(false);
        losseScreen.gameObject.SetActive(true);
    }

    public void LevelCleared()
    {
        levelMenu.SetActive(false);
        winScreen.gameObject.SetActive(true);
    }

    public void IsLevelCleared()
    {
        totalOffEnemies--;
        if(totalOffEnemies <= 0) 
        {
            LevelCleared();
        }
    }
}
