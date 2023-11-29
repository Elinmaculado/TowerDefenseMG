using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ammoattack : MonoBehaviour
{
    [SerializeField] private float index;
    [SerializeField] private float timeLife = 5;
    private ShootStats st;
    [SerializeField] private Enemy_Detector ED;
    [SerializeField] private GameObject Enemy;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        st = GetComponent<ShootStats>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index > timeLife)
        {
            Destroy(gameObject);
        }
        else
        {
            index += Time.deltaTime;
        }
    }

    void Aim()
    {
        Enemy = ED.Enemylist[0];
        Vector3 Direction = (Enemy.transform.position - transform.position);
        move(Direction);
    }

    void move(Vector3 Direction)
    {
        rb.AddForce( Direction *st.speed*Time.deltaTime);
        move(Direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            ED = other.GetComponentInChildren<Enemy_Detector>();
            Aim();
        }
    }

}
