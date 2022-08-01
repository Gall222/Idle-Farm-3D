using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class PlayerHarvestingSystem : IEcsRunSystem
    {
        EcsFilter<PlayerComponent, PlayerHarvestingComponent, AnimationComponent> playerFilter = null;
        public void Run()
        {
            Cutting();
        }
        private void Cutting()
        {
            foreach (var i in playerFilter)
            {
                ref PlayerComponent playerComponent = ref playerFilter.Get1(i);
                //ref PlayerHarvestingComponent playerHarvestingComponent = ref playerFilter.Get2(i);
                ref AnimationComponent animationComponent = ref playerFilter.Get3(i);

                playerComponent.player.scythe.gameObject.SetActive(true);
                animationComponent.animator.SetTrigger("Harvesting");
                
                ref var entity = ref playerFilter.GetEntity(i);
                entity.Del<PlayerHarvestingComponent>();
            }
        }
    }
}