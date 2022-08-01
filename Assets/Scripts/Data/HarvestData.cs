using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu]
    public class HarvestData : ScriptableObject
    {
        public GameObject harvestPrefab;
        public GameObject resultPrefab;
        public float growSpeedInSec = 10f;
    }
}