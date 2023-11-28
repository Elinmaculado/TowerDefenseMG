using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Stats : MonoBehaviour
{
    // public 
    public int TowerPrice;
    public float TowerRange;
    public int ammoSpeed;
    // private

    // private modificables en editor
    [SerializeField] private float TowerDamage;
    [SerializeField] private float TowerAttackSpeed;
    [SerializeField] private SphereCollider SphereCollider;

    public void Tower_Upgrade()
    {
        TowerDamage += TowerDamage * .25f;
        TowerAttackSpeed += TowerAttackSpeed * .25f;
        TowerRange += TowerRange * .25f;
    }

    private void Update()
    {
        SphereCollider.radius = TowerRange;
    }

}
