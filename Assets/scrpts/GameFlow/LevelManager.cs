using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{   
    public Image blackBackground;
    private bool isSceneLoading ;
    private void Start()
    {
        isSceneLoading = false;
        StartCoroutine(FadeIn());
    }
    public void LoadLevel(int level)
    {
        if (!isSceneLoading)
        {
            isSceneLoading = true;
            StartCoroutine(FadeOut(level));
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        if (!isSceneLoading)
        {
            isSceneLoading = true;  
            Time.timeScale = 1.0f;
            StartCoroutine(FadeOut(SceneManager.GetActiveScene().buildIndex));   
        }
          
    }

    IEnumerator FadeIn()
    {
        Color c = blackBackground.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBackground.color = c;
            yield return null;
        }

    }

    IEnumerator FadeOut(int scene)
    {
        Time.timeScale = 1.0f;
        Color c = blackBackground.color;
        for (float alpha = 0f; alpha < 1; alpha += 2f * Time.deltaTime)
        {
            c.a = alpha;
            blackBackground.color = c;
            yield return null;
        }
        SceneManager.LoadScene(scene);
    }
}

