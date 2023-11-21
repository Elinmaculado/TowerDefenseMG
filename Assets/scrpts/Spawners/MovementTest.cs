using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Suicide());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * 10;
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
