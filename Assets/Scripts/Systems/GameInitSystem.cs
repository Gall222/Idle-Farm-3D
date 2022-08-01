using Leopotam.Ecs;
using System;
using Components;
using UnityEngine;
using Random = UnityEngine.Random;
using Data;
//using UnityEngine.InputSystem;

namespace Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        public static Action LaserFire;

        EcsWorld _world = null;
        private StaticData _staticData;
        private SceneDataComponent _sceneData;

        public void Init()
        {
            //Time.timeScale = 1;
            //_staticData.score = 0;
            CreatePlayer();
            CreatePlants();
        }

        private void CreatePlayer()
        {
            var player = _world.NewEntity();
            var playerData = _staticData.playerInitData;
            ref MovableComponent movableComponent = ref player.Get<MovableComponent>();
            ref AnimationComponent animationComponent = ref player.Get<AnimationComponent>();
            ref PlayerComponent playerComponent = ref player.Get<PlayerComponent>();
            ref PlayerInputComponent playerInputComponent = ref player.Get<PlayerInputComponent>();
            var spawnedPlayerPrefab = GameObject.Instantiate(_staticData.playerInitData.playerPref,
                _sceneData.playerSpawnPosition.position, Quaternion.identity.normalized);
            playerComponent.player = spawnedPlayerPrefab.transform.GetComponent<Player>();
            playerComponent.audioSource = spawnedPlayerPrefab.transform.GetComponent<AudioSource>();
            animationComponent.animator = spawnedPlayerPrefab.transform.GetComponent<Animator>();
            movableComponent.transform = spawnedPlayerPrefab.transform;
            playerInputComponent.speed = playerData.speed;
            playerInputComponent.playerRigidbody = spawnedPlayerPrefab.transform.GetComponent<Rigidbody>();
            playerInputComponent.characterController = spawnedPlayerPrefab.transform.GetComponent<CharacterController>();
            _sceneData.virtualCamera.Follow = spawnedPlayerPrefab.transform;
            _sceneData.playerComponent = playerComponent;
            _sceneData.basket = playerComponent.player.basket.GetComponent<Basket>();
            _sceneData.maxHarvestInBasket = _sceneData.basket.positions.Length;
            //playerComponent.player.stepSFX = _staticData.soundsData.step;
        }

        private void CreatePlants()
        {
            foreach (var positionObj in _sceneData.plantsPositions)
            {
                var plant = _world.NewEntity();
                ref PlantComponent plantComponent = ref plant.Get<PlantComponent>();
                var spawnedPlant = GameObject.Instantiate(_staticData.harvestData.harvestPrefab,
                positionObj.transform.position, Quaternion.identity.normalized);
                //plantComponent.transform = spawnedPlant.transform;
                plantComponent.harvestView = spawnedPlant.GetComponent<Harvest>();
                plantComponent.growSpeedInSec = _staticData.harvestData.growSpeedInSec;
                plantComponent.currentScale = plantComponent.maxScale = spawnedPlant.transform.localScale;
                plantComponent.positionObj = positionObj;
                plantComponent.sliceMaterial = plantComponent.harvestView.sliceMaterial;
                spawnedPlant.transform.parent = _sceneData.plantsParent.transform;
                spawnedPlant.transform.rotation = _staticData.harvestData.harvestPrefab.transform.rotation;
                spawnedPlant.transform.Rotate(0, Random.Range(0f, 360f),0);
            }
        }


    }
}