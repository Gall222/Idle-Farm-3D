using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Transform[] positions;
    private void OnTriggerEnter(Collider other)
    {
        var harvest = other.GetComponent<HarvestResult>();
        //if (harvest && other.GetType() == typeof(CapsuleCollider))
        if (harvest)
        {
            harvest.IsBasketCollision = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        var harvest = other.GetComponent<HarvestResult>();
        if (harvest)
        {
            harvest.IsBasketCollision = false;
        }
    }
}
