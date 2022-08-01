using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject scythe;
    public GameObject basket;
    public bool isCutting = false;
    //public AudioClip stepSFX;

    public void StopCutting()
    {
        isCutting = false;
        scythe.SetActive(false);
    }
    //public void PlayStepSFX()
    //{
    //    AudioSource.PlayClipAtPoint(stepSFX, transform.position);
    //}
}
