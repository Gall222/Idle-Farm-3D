using Components;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class Index : MonoBehaviour
    {
        public StaticData staticData;
        public SceneDataComponent sceneData;
        EcsWorld world;
        EcsSystems systems;

        void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems
                .Add(new GameInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new PlayerHarvestingSystem())
                .Add(new PlantsCollisionSystem())
                .Add(new PlantsGrowingSystem())
                .Add(new HarvestResultMoveSystem())
                .Add(new HarvestTakenSystem())
                .Add(new MoneySystem())
                .Inject(staticData)
                .Inject(sceneData)
                .Init();

        }


        void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            systems.Destroy();
            world.Destroy();
        }
    }
}