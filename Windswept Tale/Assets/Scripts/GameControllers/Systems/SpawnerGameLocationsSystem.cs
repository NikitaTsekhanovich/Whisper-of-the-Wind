using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SpawnerGameLocationsSystem : IEcsRunSystem
    {
        private readonly GameData _gameData;
        private readonly EcsFilter<SpawnerComponent, TransformComponent, SpawnGameLocationEvent> _spawnerComponentFilter = null;

        public void Run()
        {
            foreach (var i in _spawnerComponentFilter)
            {
                ref var entity = ref _spawnerComponentFilter.GetEntity(i);

                ref var spawnerComponent = ref _spawnerComponentFilter.Get1(i);
                ref var gameLocationPrefabs = ref spawnerComponent.GameLocationPrefabs;

                ref var transformComponent = ref _spawnerComponentFilter.Get2(i);
                ref var transform = ref transformComponent.Transform;

                var randomIndexLocations = Random.Range(0, gameLocationPrefabs.Count);

                var newLocation = Object.Instantiate(
                    gameLocationPrefabs[randomIndexLocations],
                    transform);

                newLocation.transform.localPosition = new Vector3(_gameData.SpawnLocationPostionX, 0f, 0f);

                entity.Del<SpawnGameLocationEvent>();
            }
        }
    }
}

