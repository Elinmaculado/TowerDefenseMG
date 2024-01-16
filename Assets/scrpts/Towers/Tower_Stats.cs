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
    [SerializeField] public float TowerDamage;
    [SerializeField] public float TowerAttackSpeed;
    [SerializeField] private SphereCollider SphereCollider;

    private void Update()
    {
        SphereCollider.radius = TowerRange;
    }

}
