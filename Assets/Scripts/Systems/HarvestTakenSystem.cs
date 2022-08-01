using Components;
using Data;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Systems
{
    public class HarvestTakenSystem : IEcsRunSystem, IEcsInitSystem
    {
        private SceneDataComponent _sceneData;
        private StaticData _staticData;
        EcsFilter<HarvestResultComponent, HarvestTakenComponent> harvestTakenFilter = null;
        EcsFilter<HarvestResultComponent, HarvestTakenMoveComponent> harvestTakenMoveFilter = null;
        private float _takingSpeed;
        private float _nextTakeTime;

        public void Init()
        {
            _takingSpeed = _sceneData.home.takingSpeed;
            _nextTakeTime = Time.time;
        }

        public void Run()
        {
            AddToSaleQueue();
            MoveAllHarvest();
            
        }

        private void MoveAllHarvest()
        {
            foreach (var i in harvestTakenMoveFilter)
            {
                ref HarvestResultComponent harvestResultComponent = ref harvestTakenMoveFilter.Get1(i);
                harvestResultComponent.harvestResult.transform.position = Vector3.MoveTowards(harvestResultComponent.harvestResult.transform.position,
                        _sceneData.home.transform.position, harvestResultComponent.harvestResult.flySpeed * Time.deltaTime);
                //���� ������� �� ������ Home
                if (harvestResultComponent.harvestResult.transform.position == _sceneData.home.transform.position)
                {
                    //��������� � ������� ������ � �� ���������� ������
                    _sceneData.coinsToCreate.Add(harvestResultComponent.cost);
                    //������� �� ������ � ������� � ���� ��������
                    if (_sceneData.HarvestInBasket >= 0)
                        _sceneData.HarvestInBasket--;
                    ref var entity = ref harvestTakenMoveFilter.GetEntity(i);
                    GameObject.Destroy(harvestResultComponent.harvestResult.gameObject);
                    entity.Destroy();
                }
            }
        }

        private void AddToSaleQueue()
        {
            //�������� �� ���� ��������� ������ � ������ Taken, ������� ����� � ������� ������
            foreach (var i in harvestTakenFilter)
                {
                    ref HarvestResultComponent harvestResultComponent = ref harvestTakenFilter.Get1(i);                
                    //���� ������� � ���� Home � ��������� ����� �������
                    if (harvestResultComponent.harvestResult.InHome && Time.time >= _nextTakeTime)
                    {
                        _nextTakeTime = Time.time + _takingSpeed;
                    //����� �����������
                    ref var entity = ref harvestTakenFilter.GetEntity(i);
                    ref HarvestTakenMoveComponent harvestTakenMoveComponent = ref entity.Get<HarvestTakenMoveComponent>();
                    harvestResultComponent.harvestResult.transform.parent = _sceneData.collectedHarvestParent.transform;
                    AudioSource.PlayClipAtPoint(_staticData.soundsData.pop, _sceneData.playerComponent.player.transform.position, _sceneData.Volume);
                }
                }
        }

    }
}