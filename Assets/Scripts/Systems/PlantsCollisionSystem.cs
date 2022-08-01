using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Data;

namespace Systems
{
    public class PlantsCollisionSystem : IEcsRunSystem
    {
        public GameObject objectToSlice;
        EcsWorld _world = null;
        private SceneDataComponent _sceneData;
        private StaticData _staticData;
        EcsFilter<PlantComponent> plantsFilter;
        EcsFilter<PlantComponent, PlantCollisionComponent> plantsCollisionFilter;

        public void Run()
        {
            //ищем пересечени€ урожа€ и косы
            FindCollisions();
            //обрабатываем элементы, которые пересеклись с косой
            CuttingPlants();
        }

        private void FindCollisions()
        {
            foreach (var i in plantsFilter)
            {
                ref PlantComponent plantComponent = ref plantsFilter.Get1(i);
                //≈сли растение срезали, добавл€ем триггер коллизии
                if (plantComponent.harvestView.IsCutting)
                {
                    plantComponent.harvestView.IsCutting = false;
                    plantComponent.harvestView.IsReady = false;
                    ref var entity = ref plantsFilter.GetEntity(i);
                    ref PlantCollisionComponent PlantCollisionComponent = ref entity.Get<PlantCollisionComponent>();
                }
            }
        }

        private void CuttingPlants()
        {
            //Debug.Log(plantsCollisionFilter);
            foreach (var i in plantsCollisionFilter)
            {
                ref PlantComponent plantComponent = ref plantsCollisionFilter.Get1(i);
                CutPlant(plantComponent, i);
                
            }
        }

        private void CutPlant(PlantComponent plantComponent, int i)
        {
            var harvest = plantComponent.harvestView;
            //var mat = harvest.GetComponent<MeshRenderer>().material;
            ref var entity = ref plantsCollisionFilter.GetEntity(i);
            //звук срезани€
            AudioSource.PlayClipAtPoint(_staticData.soundsData.cutting, harvest.transform.position, _sceneData.Volume);
            //¬ыполнить рассечение объекта
            GameObject[] shatters = ShatterObject(harvest.transform.gameObject, plantComponent.sliceMaterial);
            //Debug.Log(shatters.Length);
            if (shatters != null && shatters.Length > 0)
            {
                //harvest.gameObject.SetActive(false);
                
                ref PlantGrowingComponent plantGrowingComponent = ref entity.Get<PlantGrowingComponent>();
                //урожай "исчезает" - уменьшаетс€ до 0
                harvest.transform.localScale = Vector3.zero;
                plantGrowingComponent.scaleStep = new Vector3(
                    plantComponent.maxScale.x / plantComponent.growSpeedInSec, 
                    plantComponent.maxScale.y / plantComponent.growSpeedInSec,
                    plantComponent.maxScale.z / plantComponent.growSpeedInSec) ;
                // add rigidbodies and colliders
                foreach (GameObject shatteredObject in shatters)
                {
                    shatteredObject.AddComponent<MeshCollider>().convex = true;
                    shatteredObject.AddComponent<Rigidbody>();
                    shatteredObject.layer = LayerMask.NameToLayer("Parts");
                }
                Coroutines.StartRoutine(destroyShatters(shatters));
                //создаем упавшие початки
                CreateResult(harvest.transform);
            }
            entity.Del<PlantCollisionComponent>();
        }

        private void CreateResult(Transform position)
        {
            var harvestResultEntity = _world.NewEntity();
            ref HarvestResultComponent harvestResultComponent = ref harvestResultEntity.Get<HarvestResultComponent>();
            //метка Idle дл€ HarvestResultMoveSystem - урожай лежит на земле
            ref HarvestIdleComponent harvestIdleComponent = ref harvestResultEntity.Get<HarvestIdleComponent>();
            var spawnedPrefab = GameObject.Instantiate(_staticData.harvestData.resultPrefab, position.position, Quaternion.identity.normalized);
            var harvestResult = spawnedPrefab.GetComponent<HarvestResult>();
            harvestResultComponent.harvestResult = harvestResult;
            harvestResultComponent.cost = harvestResult.cost;
            harvestResultComponent.harvestState = HarvestResultComponent.HarvestStates.jump;
            harvestResultComponent.flySpeed = harvestResult.flySpeed;

        }

        IEnumerator destroyShatters(GameObject[] shatters)
        {
            yield return new WaitForSeconds(2);
            foreach (GameObject shatteredObject in shatters)
            {
                GameObject.Destroy(shatteredObject);
            }

        }
        public GameObject[] ShatterObject(GameObject obj, Material crossSectionMaterial = null)
        {
            return obj.SliceInstantiate(
                //GetRandomPlane(obj.transform.position, obj.transform.localScale),
                new EzySlice.Plane(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f)),
                //new EzySlice.Plane(new Vector3(0f, 0f, 0f), Vector3.down),
                new TextureRegion(0.0f, 0.0f, 1.0f, 1.0f),
                crossSectionMaterial);
        }
        public EzySlice.Plane GetRandomPlane(Vector3 positionOffset, Vector3 scaleOffset)
        {
            Vector3 randomPosition = Random.insideUnitSphere;
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            Debug.Log($"{randomPosition}; {randomDirection}");
            return new EzySlice.Plane(randomPosition, randomDirection);
        }
    }
}