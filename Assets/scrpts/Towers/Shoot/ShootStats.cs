using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStats : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float damage;
    [SerializeField] private bool itsCannon;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(itsCannon)
            {
                cannonExprosion();
            }
            else
            {
                Destroy(this.gameObject,.25f);
            }
        }
    }

    public void Boom()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);

        if(itsCannon)
        {
            cannonExprosion();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    private void cannonExprosion()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(gameObject,.5f);
    }
}
