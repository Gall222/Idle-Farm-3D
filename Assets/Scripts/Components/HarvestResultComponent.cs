using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Components
{
    public struct HarvestResultComponent
    {
        public HarvestResult harvestResult;
        public int cost;
        public HarvestStates harvestState;
        public Tweener tweener;
        public Vector3 lastBasketPosition;
        public float flySpeed;
        public Sequence sequence;
        public enum HarvestStates
        {
            jump,
            move,
            collected
        }
    }
}