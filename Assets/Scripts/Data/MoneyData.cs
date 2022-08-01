using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class MoneyData : ScriptableObject
    {
        public GameObject moneyPref;
        public float speed = 20f;
        public float createTime = 0.5f;
    }
}
