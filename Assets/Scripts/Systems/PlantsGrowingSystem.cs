using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class PlantsGrowingSystem : IEcsRunSystem
    {
        private SceneDataComponent _sceneData;
        EcsFilter<PlantComponent, PlantGrowingComponent> plantsFilter;

        public void Run()
        {
            foreach (var i in plantsFilter)
            {
                ref PlantComponent plantComponent = ref plantsFilter.Get1(i);
                ref PlantGrowingComponent plantGrowingComponent = ref plantsFilter.Get2(i);
                if (Time.time >= plantGrowingComponent.timeToNextStep)
                {
                    plantGrowingComponent.timeToNextStep = Time.time + 1;
                    plantComponent.harvestView.transform.localScale += plantGrowingComponent.scaleStep;
                    //var localScale = plantComponent.harvestView.transform.localScale;

                    if (plantComponent.harvestView.transform.localScale.x >= plantComponent.maxScale.x)
                    {
                        ref var entity = ref plantsFilter.GetEntity(i);
                        plantComponent.harvestView.IsReady = true;
                        entity.Del<PlantGrowingComponent>();
                    }
                }
            }
        }
    }
}