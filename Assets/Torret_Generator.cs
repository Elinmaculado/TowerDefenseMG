using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret_Generator : MonoBehaviour
{
    public GResourceManager ResourceManager;
    [SerializeField] private float MoneyAmount = 25f;
    [SerializeField] private float GenerationSpeed = 5f;
    [SerializeField] private Tower_Stats ts;
    [SerializeField] private ParticleSystem torretParticles;
    private void Start()
    {
        ts = GetComponentInChildren<Tower_Stats>();
        ResourceManager = FindAnyObjectByType<GResourceManager>();
        StartCoroutine(GenerateResource());
    }
    IEnumerator GenerateResource()
    {
        MoneyAmount = ts.TowerDamage;
        GenerationSpeed = ts.TowerAttackSpeed;
        yield return new WaitForSeconds(GenerationSpeed);
        torretParticles.Play();
        ResourceManager.AddResources(MoneyAmount);
        StartCoroutine(GenerateResource());
    }
}
