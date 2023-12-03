using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStats : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, .5f);
        }
    }
}
