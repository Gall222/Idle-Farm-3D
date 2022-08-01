using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Data;

namespace Systems
{
    public class MoneySystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        private int _moneyToAdd = 0;
        private float _nextMoneyAddTime;
        private float _nextCoinCreateTime = 0;

        private SceneDataComponent _sceneData;
        private StaticData _staticData;
        EcsFilter<MoneyComponent> moneyFilter = null;
        public void Run()
        {
            CoinsCreateProcess();
            Moving();
            AddMoney();
        }

        private void AddMoney()
        {
            if (_moneyToAdd > 0 && Time.time >= _nextMoneyAddTime)
            {
                _nextMoneyAddTime = Time.time + _sceneData.moneyAddSpeed;
                _moneyToAdd--;
                _sceneData.Score++;
            }
        }

        private void Moving()
        {
            foreach (var i in moneyFilter)
            {
                ref MoneyComponent moneyComponent = ref moneyFilter.Get1(i);
                moneyComponent.transform.position = Vector3.MoveTowards(moneyComponent.transform.position,
                        _sceneData.scoreText.transform.position, moneyComponent.speed * Time.deltaTime);

                //если монета долетела до счета
                if (Camera.main.ScreenToWorldPoint(moneyComponent.transform.position) ==
                    Camera.main.ScreenToWorldPoint(_sceneData.scoreText.transform.position))
                {
                    Sale(moneyComponent);
                    ref var entity = ref moneyFilter.GetEntity(i);
                    GameObject.Destroy(moneyComponent.transform.gameObject);
                    entity.Destroy();
                    AudioSource.PlayClipAtPoint(_staticData.soundsData.coin, _sceneData.playerComponent.player.transform.position, _sceneData.Volume);
                }
            }
        }
        private void Sale(MoneyComponent moneyComponent)
        {
            _sceneData.scoreText.transform.DOPunchScale(_sceneData.punchForce, 1);


            _moneyToAdd += moneyComponent.cost;

        }
        private void CreateCoin(int cost)
        {
            var coinEntity = _world.NewEntity();
            var spawnedPrefab = GameObject.Instantiate(
                _staticData.moneyData.moneyPref,
                Camera.main.WorldToScreenPoint(_sceneData.home.transform.position),
                Quaternion.identity.normalized);
            ref MoneyComponent moneyComponent = ref coinEntity.Get<MoneyComponent>();
            moneyComponent.transform = spawnedPrefab.transform;
            moneyComponent.cost = cost;
            moneyComponent.speed = _staticData.moneyData.speed;
            spawnedPrefab.transform.SetParent(_sceneData.canvas.transform);
            spawnedPrefab.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        private void CoinsCreateProcess()
        {
            foreach (var coin in _sceneData.coinsToCreate)
            {
                if (_nextCoinCreateTime == 0)
                    _nextCoinCreateTime = Time.time + _staticData.moneyData.createTime;
                if (Time.time >= _nextCoinCreateTime)
                {
                    _nextCoinCreateTime = Time.time + _staticData.moneyData.createTime;
                    CreateCoin(coin);
                    _sceneData.coinsToCreate.Remove(coin);
                    return;
                }
            }
            if (_sceneData.coinsToCreate.Count <= 0)
            {
                _nextCoinCreateTime = 0;
            }
        }
    }
}