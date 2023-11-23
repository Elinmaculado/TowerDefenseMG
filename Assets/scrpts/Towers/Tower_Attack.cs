using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //public

    //private
    private Enemy_Detector ED;

    // private modificables en el editor
    [SerializeField ]private GameObject stats;
    private void Update()
    {
        if (ED.Enemylist.Count > 0)
        {

        }
    }
    
    void Torret_Shot()
    {

    }
}
