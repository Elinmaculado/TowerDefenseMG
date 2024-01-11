using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private int downUpgradeTier;
    Tower_Stats ts;

    // aqui va a ver codigo

    private void Start()
    {
        ts= GetComponent<Tower_Stats>();
    }

    public void topUpgrade()
    {
        if(downUpgradeTier <=2) 
        {
            Debug.Log(" el camino esta bloqueado");
        }
        else
        {
            ts.TowerRange += Range[topUpgradeTier];
            ts.ammoSpeed += ammoSpeed[topUpgradeTier];
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
            ts.TowerDamage += Damage[downUpgradeTier]; 
            ts.TowerAttackSpeed += AttackSpeed[downUpgradeTier];
        }
    }
}
