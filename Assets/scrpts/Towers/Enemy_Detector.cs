using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 10);
    }
}
