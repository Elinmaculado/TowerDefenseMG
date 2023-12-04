using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider hitbox;
    [SerializeField] EnemyBehavior EB;

    void Start()
    {
        EB.GetComponent<EnemyBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Shoot")
        {
            EB.TakeDamage(other.gameObject.GetComponent<ShootStats>().damage);

        }
    }


}
