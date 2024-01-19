using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] List<GameObject> turrets;
    [SerializeField] List<Image> turretImages;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager in scene");
            return;
        }
        instance = this; 
    }

    public GameObject standerdTurretPrefab;

    private void Start()
    {
        turretBuild = standerdTurretPrefab;
        turretImages[0].color = Color.red;
    }


    public GameObject turretBuild;

    public GameObject GetTurretToBuild()
    {
        return turretBuild;
    }

    public void SetTurret(int turret)
    {
        for(int i = 0; i < turretImages.Count; i++) { turretImages[i].color = Color.white; }
        turretBuild = turrets[turret];
        turretImages[turret].color = Color.red;
    }
}
