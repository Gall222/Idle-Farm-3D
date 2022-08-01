using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Data;

namespace Systems
{
    public class HarvestResultMoveSystem : IEcsRunSystem
    {
        private SceneDataComponent _sceneData;
        private StaticData _staticData;
        EcsFilter<HarvestResultComponent, HarvestIdleComponent> harvestResultCollisionFilter = null;
        EcsFilter<HarvestResultComponent, HarvestResultMoveComponent> harvestResultMoveFilter = null;

        public void Run()
        {
            IsCollision();
            Moving();
        }

        private void IsCollision()
        {
            foreach (var i in harvestResultCollisionFilter)
            {
                ref var entity = ref harvestResultCollisionFilter.GetEntity(i);
                ref HarvestResultComponent harvestResultComponent = ref harvestResultCollisionFilter.Get1(i);
                //если игрок в зоне коллайдера, добавить метку для перемещения и если в рюкзаке есть место
                if (harvestResultComponent.harvestResult.IsPlayerCollision &&
                    _sceneData.HarvestInBasket < _sceneData.maxHarvestInBasket)
                {
                    _sceneData.HarvestInBasket++;
                    //метка - урожай летит в корзину
                    ref HarvestResultMoveComponent harvestResultMoveComponent = ref entity.Get<HarvestResultMoveComponent>();
                    entity.Del<HarvestIdleComponent>();
                }
            }
        }

        private void Moving()
        {
            foreach (var i in harvestResultMoveFilter)
            {
                ref var entity = ref harvestResultMoveFilter.GetEntity(i);
                ref HarvestResultComponent harvestResultComponent = ref harvestResultMoveFilter.Get1(i);

                //прыжок выполняется 1 раз 
                DoJump(ref harvestResultComponent);
                //двигаем к корзине весь собранный урожай
                MoveAllHarvest(ref harvestResultComponent);
                //удаляем метку движения, если достигли корзины
                EndMove(ref entity, ref harvestResultComponent);
            }
        }

        private void DoJump(ref HarvestResultComponent harvestResultComponent)
        {
             //jump по дефолту, переключаем его на move
            if (harvestResultComponent.harvestState != HarvestResultComponent.HarvestStates.jump) { return; }
            harvestResultComponent.harvestState = HarvestResultComponent.HarvestStates.move;

            harvestResultComponent.sequence = DOTween.Sequence();
            harvestResultComponent.sequence.Append(
            harvestResultComponent.harvestResult.transform.DOJump(
                new Vector3(
                    _sceneData.basket.transform.position.x,
                    _sceneData.basket.transform.position.y * 2,
                    _sceneData.basket.transform.position.z),
                4, 1, 1)
                );

            
            
        }
        private void MoveAllHarvest(ref HarvestResultComponent harvestResultComponent)
        {
            if (harvestResultComponent.harvestState != HarvestResultComponent.HarvestStates.move) { return; }

            harvestResultComponent.harvestResult.transform.position = Vector3.MoveTowards(harvestResultComponent.harvestResult.transform.position,
                        _sceneData.basket.transform.position, harvestResultComponent.harvestResult.flySpeed * Time.deltaTime);
        }
        private void EndMove(ref EcsEntity entity, ref HarvestResultComponent harvestResultComponent)
        {
            if (!harvestResultComponent.harvestResult.IsBasketCollision) { return; }
            harvestResultComponent.sequence.Kill();
            harvestResultComponent.harvestState = HarvestResultComponent.HarvestStates.collected;
            entity.Del<HarvestResultMoveComponent>();
            harvestResultComponent.harvestResult.gameObject.layer = LayerMask.NameToLayer("CollectedHarvest");
            harvestResultComponent.harvestResult.GetComponent<Rigidbody>().isKinematic = true;
            AddToBasket(ref harvestResultComponent);
            //добавляем метку собранного в рюкзак урожая
            ref HarvestTakenComponent harvestTakenComponent = ref entity.Get<HarvestTakenComponent>();

            AudioSource.PlayClipAtPoint(_staticData.soundsData.pop, _sceneData.playerComponent.player.transform.position, _sceneData.Volume);
        }
        private void AddToBasket(ref HarvestResultComponent harvestResultComponent)
        {
            foreach (var pos in _sceneData.basket.positions)
            {
                if (pos.transform.childCount <= 0)
                {
                    harvestResultComponent.harvestResult.transform.parent = pos.transform;
                    harvestResultComponent.harvestResult.transform.localPosition = Vector3.zero;
                    harvestResultComponent.harvestResult.transform.rotation = pos.rotation;
                    return;
                }
            }
        }

    }
}