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
    [SerializeField] public List<GameObject> Enemylist;
    [SerializeField] private GameObject ammo;
    [SerializeField] Tower_Stats ts;

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
                 apuntar();
                if (indextime > ts.TowerAttackSpeed)
                {
                    GameObject BalaTemp = Instantiate(ammo, spawner.transform.position, spawner.transform.rotation) as GameObject;

                    BalaTemp.GetComponent<ShootStats>().damage = ts.TowerDamage;

                    Rigidbody rb = BalaTemp.GetComponent<Rigidbody>();

                    rb.AddForce((Enemylist[0].transform.position - transform.position) * ts.ammoSpeed);

                    Destroy(BalaTemp, 5.0f);
                    indextime = 0;
                }
                indextime += Time.deltaTime;
            
            }
             else
             {
                Enemylist.RemoveAt(0);
             }
           
        }
       
        
    }

    // apuntado
    void apuntar()
    {
        torret.transform.LookAt(Enemylist[0].transform.position);
        spawner.transform.LookAt(Enemylist[0].transform.position);
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
