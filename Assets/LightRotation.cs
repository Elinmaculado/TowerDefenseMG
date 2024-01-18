using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private float tmpRotation;

    private void Update()
    {
        tmpRotation = (transform.rotation.x + rotationSpeed) * Time.deltaTime;
        transform.Rotate(new Vector3(tmpRotation, transform.rotation.y, transform.rotation.z));
    }
}
