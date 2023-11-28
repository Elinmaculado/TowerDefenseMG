using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GResourceManager : MonoBehaviour
{
    public Text TextoRecurso;
    private float RecursosActuales;
    // Start is called before the first frame update
    void Start()
    {
        RecursosActuales = 0f;
        UpdateUI();
    }


    public void UpdateUI()
    {
        TextoRecurso.text = "Dinero: $" + RecursosActuales;
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

}