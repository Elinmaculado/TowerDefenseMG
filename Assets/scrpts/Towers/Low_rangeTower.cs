using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Low_rangeTower : MonoBehaviour
{
    // public

    // private
    private float indextime;
    //private modificables en editor
    [SerializeField] private GameObject torret;
    [SerializeField] public List<GameObject> Enemylist;
    [SerializeField] private List<GameObject> spawnerlist;
    [SerializeField] private GameObject ammo;
    [SerializeField] Tower_Stats ts;
    [SerializeField] ParticleSystem efectoDeDisparo;

    private void Start()
    {
        ts.GetComponent<Tower_Stats>();
    }
    private void Update()
    {
        if (Enemylist.Count > 0)
        {
            if (!(Enemylist[0].GetComponentInParent<EnemyBehavior>().isDead))
            {
                attack();
            }
            else
            {
                Enemylist.RemoveAt(0);
            }
            for (int i = 0; i < Enemylist.Count; i++)
            {
                if (Enemylist[i].GetComponentInParent<EnemyBehavior>().isDead)
                {
                    Enemylist.RemoveAt(i);
                }
            }
        }
        else
        {
            indextime = 0;
        }

    }
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

    private void attack()
    {
        if(indextime > ts.TowerAttackSpeed)
        {
            efectoDeDisparo.Play();
            for (int i = 0; i < spawnerlist.Count; i++)
            {
                GameObject BalaTemp = Instantiate(ammo, spawnerlist[i].transform.position, spawnerlist[i].transform.rotation) as GameObject;

                BalaTemp.GetComponent<ShootStats>().damage = ts.TowerDamage;

                Rigidbody rb = BalaTemp.GetComponent<Rigidbody>();

                rb.AddForce((spawnerlist[i].transform.position - transform.position) * ts.ammoSpeed);

                Destroy(BalaTemp, 5.0f);
            }
            indextime = 0;
        }
        indextime += Time.deltaTime;
    }
}
