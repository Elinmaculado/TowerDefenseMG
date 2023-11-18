using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int TargetIndex = 1;
    public float movementSpeed;
    public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LookAt();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[TargetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[TargetIndex].position);

        if (distance <= 0.1f) 
        {
            if (TargetIndex >= waypoints.Count-1) 
            {
                Debug.Log("El enemigo llegó al final");
                return;
            }
            else
            {
                TargetIndex++;
                //LookAt();
            }
        }
    }

    private void LookAt()
    {
        //Metodo brusco
        //transform.LookAt(waypoints[TargetIndex]);

        //metodo mas suave
        var dir = waypoints[TargetIndex].position - transform.position;
        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);

    }
}
