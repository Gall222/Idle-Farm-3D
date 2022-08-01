using UnityEngine;

namespace Components
{
    public struct PlantComponent 
    {
        public GameObject positionObj;
        public Harvest harvestView;
        public float growSpeedInSec;
        public Vector3 currentScale;
        public Vector3 maxScale;
        public Material sliceMaterial;
    }
}