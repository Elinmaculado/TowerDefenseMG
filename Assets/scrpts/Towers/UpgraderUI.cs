using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgraderUI : MonoBehaviour
{
    private Tower_Upgrader toUpdate = null;
    public static UpgraderUI instance;
    public Image topUpgrade;
    public Image downUpgrade;
    public TextMeshProUGUI topDescription;
    public TextMeshProUGUI downDescription; 
    public TextMeshProUGUI topCost;
    public TextMeshProUGUI downCost;




    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void SetUI(Tower_Upgrader towerToUpgrade)
    {
        topUpgrade.fillAmount = towerToUpgrade.topUpgradeTier/ 4;
        topDescription.text = towerToUpgrade.topDescription;
        topCost.text = towerToUpgrade.DownCost().ToString() + "$";
        downUpgrade.fillAmount = towerToUpgrade.downUpgradeTier / 4;
        downDescription.text = towerToUpgrade.downDescription;
        downCost.text = towerToUpgrade.TopCost().ToString() + "$";
        toUpdate = towerToUpgrade;
        
    }

    public void UpgradeTop()
    {
        if(toUpdate == null)
        {
            topDescription.text = "No tower selected";
        }
        else
        {
            toUpdate.topUpgrade(topDescription,topCost);
        }
    }

    public void UpgradeDown()
    {
        if (toUpdate == null)
        {
            downDescription.text = "No tower selected";
        }
        else
        {
            toUpdate.downUpgrade(downDescription,downCost);
        }
    }




}
