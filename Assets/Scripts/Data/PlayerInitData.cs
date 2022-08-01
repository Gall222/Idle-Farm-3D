using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class PlayerInitData : ScriptableObject
    {
        public GameObject playerPref;
        //public float boost = 500f;
        public float speed = 30f;

    }
}