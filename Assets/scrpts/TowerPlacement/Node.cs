using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret = null;

    private Renderer originalRenderer;
    private Color startColor;

   


    private void Start()
    {
        originalRenderer = GetComponent<Renderer>();
        startColor = originalRenderer.material.color;
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
            Debug.Log("No turret in here");
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        }
    }
}
