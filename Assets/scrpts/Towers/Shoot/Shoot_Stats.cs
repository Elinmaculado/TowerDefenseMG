using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Stats : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
