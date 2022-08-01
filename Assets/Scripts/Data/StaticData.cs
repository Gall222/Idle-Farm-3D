using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public PlayerInitData playerInitData;
        public HarvestData harvestData;
        public MoneyData moneyData;
        public SoundsData soundsData;

        //public Queue<EcsEntity> EnemiesEntities = new Queue<EcsEntity>();
    }

}