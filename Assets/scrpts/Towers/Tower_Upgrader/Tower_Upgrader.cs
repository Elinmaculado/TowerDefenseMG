using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower_Upgrader : MonoBehaviour
{
    [SerializeField] private List<int> Range;
    [SerializeField] private List<int> AttackSpeed;
    [SerializeField] private List<int> Damage;
    [SerializeField] private List<int> ammoSpeed;
    [SerializeField] private int topUpgradeTier;
    Tower_Stats ts;
    // aqui va a ver codigo

    private void Start()
    {
        ts= GetComponent<Tower_Stats>();
    }

}
