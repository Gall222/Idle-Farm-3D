using Leopotam.Ecs;
using UnityEngine;

namespace Components
{
    public struct PlantGrowingComponent
    {
        public float timeToNextStep;
        public Vector3 scaleStep;
    }
}