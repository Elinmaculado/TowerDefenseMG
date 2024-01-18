using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Tower_Upgrader : MonoBehaviour
{
    [SerializeField] private List<float> Range;
    [SerializeField] private List<float> AttackSpeed;
    [SerializeField] private List<float> Damage;
    [SerializeField] private List<int> ammoSpeed;
    public int topUpgradeTier;
    [SerializeField] private List<int> topUpgradeCost;
    public int downUpgradeTier;
    [SerializeField] private List<int> downUpgradeCost;
    [SerializeField] Tower_Stats ts;
    public GResourceManager ResourceManager;
    [SerializeField] private ParticleSystem upgradeEffect;
    public string topDescription;
    public string downDescription;

    // aqui va a ver codigo

    private void Start()
    {
        ts= GetComponentInChildren<Tower_Stats>();
        ResourceManager = FindAnyObjectByType<GResourceManager>();
    }

    public void topUpgrade(TextMeshProUGUI topDescription, TextMeshProUGUI topCost)
    {
        if(downUpgradeTier >=2) 
        {
            string originalText = topDescription.text;
            topDescription.text = "Path locked";
            StartCoroutine(ReturnText(topDescription, originalText, 2.5f));
        }
        else
        {
            if (ResourceManager.RecursosActuales >= topUpgradeCost[topUpgradeTier])
            {
                ResourceManager.RemoveResources(topUpgradeCost[topUpgradeTier]);
                ts.TowerRange = Range[topUpgradeTier];
                ts.TowerAttackSpeed = AttackSpeed[topUpgradeTier];
                topUpgradeTier++;
                topCost.text = topUpgradeCost[topUpgradeTier].ToString() + "$";
                upgradeEffect.Play();
            }
        }
    }

    public void downUpgrade(TextMeshProUGUI downDescription, TextMeshProUGUI downCost)
    {
        if(topUpgradeTier >=2)
        {
            string originalText = downDescription.text;
            downDescription.text = "Path locked";
            StartCoroutine(ReturnText(downDescription, originalText, 2.5f));
        }
        else
        {
            if (ResourceManager.RecursosActuales >= topUpgradeCost[downUpgradeTier])
            {
                ResourceManager.RemoveResources(topUpgradeCost[downUpgradeTier]);
                ts.TowerDamage = Damage[downUpgradeTier];
                ts.ammoSpeed = ammoSpeed[downUpgradeTier];
                downUpgradeTier++;
                downCost.text = topUpgradeCost[downUpgradeTier].ToString() + "$";
                upgradeEffect.Play();
            }
        }
    }

    public int TopCost()
    {
        return topUpgradeCost[topUpgradeTier];
    }  
    public int DownCost()
    {
        return topUpgradeCost[topUpgradeTier];
    }

    IEnumerator ReturnText(TextMeshProUGUI textSource, string text, float returnTime)
    {
        yield return new WaitForSeconds(returnTime);
        textSource.text = text;
    }
    public void AddCost(int cost)
    {
        ts.TowerPrice += cost;
    }
}
