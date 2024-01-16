using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Tower_Upgrader : MonoBehaviour
{
    [SerializeField] private List<int> Range;
    [SerializeField] private List<int> AttackSpeed;
    [SerializeField] private List<int> Damage;
    [SerializeField] private List<int> ammoSpeed;
    [SerializeField] private int topUpgradeTier;
    [SerializeField] private List<int> topUpgradeCost;
    [SerializeField] private int downUpgradeTier;
    [SerializeField] private List<int> downUpgradeCost;
    [SerializeField] Tower_Stats ts;
    public GResourceManager ResourceManager;
    [SerializeField] private ParticleSystem upgradeEffect;

    // aqui va a ver codigo

    private void Start()
    {
        ts= GetComponentInChildren<Tower_Stats>();
        ResourceManager = FindAnyObjectByType<GResourceManager>();
    }

    public void topUpgrade()
    {
        if(downUpgradeTier <=2) 
        {
            Debug.Log(" el camino esta bloqueado");
        }
        else
        {
            if (ResourceManager.RecursosActuales > topUpgradeCost[topUpgradeTier])
            {
                ResourceManager.RecursosActuales -= topUpgradeCost[topUpgradeTier];
                ts.TowerRange += Range[topUpgradeTier];
                ts.TowerAttackSpeed += AttackSpeed[downUpgradeTier];
                upgradeEffect.Play();
            }
            else
            {
                Debug.Log("el piojo");
            }
        }
    }

    public void downUpgrade()
    {
        if(topUpgradeTier <=2)
        {
            Debug.Log("camino bloqueado");
        }
        else
        {
            if (ResourceManager.RecursosActuales > topUpgradeCost[topUpgradeTier])
            {
                ResourceManager.RecursosActuales -= topUpgradeCost[topUpgradeTier];
                ts.TowerDamage += Damage[downUpgradeTier];
                ts.ammoSpeed += ammoSpeed[topUpgradeTier];
                upgradeEffect.Play();
            }
            else
            {
                Debug.Log("el piojo");
            }
        }
    }
    public void AddCost(int cost)
    {
        ts.TowerPrice += cost;
    }
}
