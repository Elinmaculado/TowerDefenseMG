using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{
    // public
    public List<GameObject> Enemylist;
    // private

    //private modificables en editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("entro un malo maloso");
           Enemylist.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ya se te fue el malo maloso");
            Enemylist.Remove(other.gameObject);
        }
    }
}
