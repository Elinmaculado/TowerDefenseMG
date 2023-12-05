using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GResourceManager : MonoBehaviour
{
    public Text TextoRecurso;
    public float RecursosActuales = 0f;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }


    public void UpdateUI()
    {
        TextoRecurso.text = "Cash: $" + RecursosActuales;
    }

    public void AddResources(float valor)
    {
        RecursosActuales += valor;
        UpdateUI();
    }
    public void RemoveResources(float valor)
    {
        RecursosActuales -= valor;
        UpdateUI();
    }
    public float CurrentResources()
    {
        return RecursosActuales;
    }
}