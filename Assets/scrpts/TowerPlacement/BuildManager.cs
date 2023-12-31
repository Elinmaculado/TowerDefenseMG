using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] List<GameObject> turrets;

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
    }


    public GameObject turretBuild;

    public GameObject GetTurretToBuild()
    {
        return turretBuild;
    }

    public void SetTurret(int turret)
    {
        turretBuild = turrets[turret];
    }
}
