using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnOff : MonoBehaviour
{

    [SerializeField] private List<GameObject> on;
    [SerializeField] private List<GameObject> off;

    public void OnOff()
    {
        for (int i = 0; i < off.Count; i++)
        {
            off[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < on.Count; i++)
        {
            on[i].gameObject.SetActive(true);
        }
        
    }
}
