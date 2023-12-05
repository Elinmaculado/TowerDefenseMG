using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMonGenerator : MonoBehaviour
{
    public GResourceManager ResourceManager;
    public float MoneyAmount = 25f;
    public float GenerationSpeed = 5f;

    // Update is called once per frame

    private void Start()
    {
        ResourceManager = FindAnyObjectByType<GResourceManager>();
        StartCoroutine(GenerateResource());
    }
    IEnumerator GenerateResource()
    {
        yield return new WaitForSeconds(GenerationSpeed);
        ResourceManager.AddResources(MoneyAmount);
        StartCoroutine(GenerateResource());
        
    }
    
}
