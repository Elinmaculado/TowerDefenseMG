using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{
    // public

    // private
    private float indextime;
    //private modificables en editor
    [SerializeField] private GameObject torret,spawner;
    [SerializeField] private List<GameObject> Enemylist;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float ShootTime;
    private void Update()
    {
        if (Enemylist.Count > 0 )
        {
            apuntar();
            if(indextime > ShootTime)
            {
                DisparaNegro();
                indextime = 0;
            }
            indextime += Time.deltaTime;
        }
        else
        {
            indextime = 0;
        }
    }

    // apuntado
    void apuntar()
    {
        torret.transform.LookAt(Enemylist[0].transform.position);
    }

    void DisparaNegro()
    {
        Instantiate(ammo, spawner.transform);
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
