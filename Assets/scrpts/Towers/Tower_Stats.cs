using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Stats : MonoBehaviour
{
    // public 
    int TowerPrice;
    public float TowerRange;
    // private

    // private modificables en editor
    [SerializeField] private float TowerDamage;
    [SerializeField] private float TowerAttackSpeed;

    public void Towwer_Upgrade()
    {
        TowerDamage += TowerDamage * .25f;
        TowerAttackSpeed += TowerAttackSpeed * .25f;
    }

}