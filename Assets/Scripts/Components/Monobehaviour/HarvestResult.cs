using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestResult : MonoBehaviour
{
    public int cost = 10;
    [Range(1, 10)]
    public float flySpeed = 7;

    private bool _inHome = false;
    private bool _isPlayerCollision = false;
    private bool _isBasketCollision = false;
    

    public bool InHome => _inHome;
    public bool IsPlayerCollision => _isPlayerCollision;
    public bool IsBasketCollision { get => _isBasketCollision; set => _isBasketCollision = value; }


    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Player>())
        {
            _isPlayerCollision = true;
        }
        else if (other.GetComponent<Home>())
        {
            _inHome = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _isPlayerCollision = false;
        }
        else if (other.GetComponent<Home>())
        {
            _inHome = false;
        }

    }
}
