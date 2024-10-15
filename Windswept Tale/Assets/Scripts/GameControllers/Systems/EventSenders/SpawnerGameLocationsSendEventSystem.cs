using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems.EventSenders
{
    public class SpawnerGameLocationsSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnGameLocationsSendEvent> _spawnGameLocationEventFilter = null;
        private readonly EcsFilter<SpawnerComponent, TransformComponent> _spawnerComponentFilter = null;

        public void Run()
        {
            foreach (var i in _spawnGameLocationEventFilter)
            {
                ref var entityEvent = ref _spawnGameLocationEventFilter.GetEntity(i);

                foreach (var j in _spawnerComponentFilter)
                {
                    ref var entitySpawner = ref _spawnerComponentFilter.GetEntity(j);
                    entitySpawner.Get<SpawnGameLocationEvent>();
                }

                entityEvent.Del<SpawnGameLocationsSendEvent>();
            }
        }
    }
}

