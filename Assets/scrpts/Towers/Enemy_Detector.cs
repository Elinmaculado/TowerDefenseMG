using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{
    // public

    // private

    //private modificables en editor
    [SerializeField] private GameObject torret;
    [SerializeField] private List<GameObject> Enemylist;

    private void Update()
    {
        if (Enemylist.Count > 0 )
        {
            apuntar();
        }
    }

    // apuntado
    void apuntar()
    {
        torret.transform.LookAt(Enemylist[0].transform.position);
    }


    // list enter and exit
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           Enemylist.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemylist.Remove(other.gameObject);
        }
    }
}
