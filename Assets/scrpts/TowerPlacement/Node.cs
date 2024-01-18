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

    [SerializeField] Texture2D hoverCursor;
    public AudioSource audioSource;
    public AudioClip sellTurret;
    public List<AudioClip> buildTurret;
    
   


    private void Start()
    {
        originalRenderer = GetComponent<Renderer>();
        startColor = originalRenderer.material.color;
        ResourceCostManager = FindAnyObjectByType<GResourceManager>();
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(hoverCursor,Vector2.zero,CursorMode.Auto);
        GetComponent<Renderer>().material.color = hoverColor;    
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        originalRenderer.material.color = startColor;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && turret != null)
        {
            audioSource.PlayOneShot(sellTurret);
            ResourceCostManager.AddResources((int)(turret.GetComponentInChildren<Tower_Stats>().TowerPrice*0.5f));
            Destroy(turret.gameObject);
            turret = null;
        }
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            UpgraderUI.instance.SetUI(turret.GetComponentInChildren<Tower_Upgrader>());
        }
        else
        {
            if (BuildManager.instance.GetTurretToBuild().GetComponentInChildren<Tower_Stats>().TowerPrice <= ResourceCostManager.RecursosActuales)
            {
                audioSource.PlayOneShot(buildTurret[Random.Range(0, buildTurret.Count)]);

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
