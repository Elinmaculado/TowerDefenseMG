using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret = null;

    private Renderer originalRenderer;
    private Color startColor;

    public GResourceManager ResourceCostManager;
   


    private void Start()
    {
        originalRenderer = GetComponent<Renderer>();
        startColor = originalRenderer.material.color;
        ResourceCostManager = FindAnyObjectByType<GResourceManager>();
    }
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hoverColor;    
    }

    private void OnMouseExit()
    {
        originalRenderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Turret in here");
        }
        else
        {
            if (BuildManager.instance.GetTurretToBuild().GetComponentInChildren<Tower_Stats>().TowerPrice <= ResourceCostManager.RecursosActuales)
            {
                Debug.Log("Hay varo");

                Debug.Log("No turret in here");

                GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

                ResourceCostManager.RemoveResources(BuildManager.instance.GetTurretToBuild().GetComponentInChildren<Tower_Stats>().TowerPrice);
            }
            else
            {
                Debug.Log("No hay varo");
            }

        }
    }
}
