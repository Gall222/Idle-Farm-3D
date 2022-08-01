using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Harvest : MonoBehaviour
{

    public bool IsCutting = false;
    public bool IsReady = true;
    public Material sliceMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (IsReady)
        {
            IsCutting = true;
        }
    }
}
