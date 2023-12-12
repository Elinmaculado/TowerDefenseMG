using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHP : MonoBehaviour
{
    public static BaseHP instance;

    //Variables de vida
    public float maxLife;
    public Image fillImage;
    [SerializeField] private float currentLife;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager in scene");
            return;
        }
      
    }

    private void Start()
    {
        instance = this;
        currentLife = maxLife;
    }

    public void TakeDamage(float damage)
    {
        float newLife = currentLife - damage;
        if (newLife <= 0)
        {
            Debug.Log("game over");
        }
        else
        {
            currentLife = newLife;
            float fillValue = currentLife * 1 / maxLife;
            fillImage.fillAmount = fillValue;
        }

    }
}
