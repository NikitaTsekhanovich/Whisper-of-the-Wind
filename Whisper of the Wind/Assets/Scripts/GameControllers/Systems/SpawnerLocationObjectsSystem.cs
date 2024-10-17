using System.Collections.Generic;
using GameControllers.Components;
using GameControllers.Components.Auxiliary;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SpawnerLocationObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnerLocationObjectsComponent, TransformComponent> _spawnerLocationObjectsFilter = null;

        public void Run()
        { 
            foreach (var i in _spawnerLocationObjectsFilter)
            {
                ref var entity = ref _spawnerLocationObjectsFilter.GetEntity(i);

                ref var spawnerLocationObjectsComponent = ref _spawnerLocationObjectsFilter.Get1(i);

                ref var flowSpawnPoints = ref spawnerLocationObjectsComponent.FlowSpawnPoints;
                ref var flowPrefab = ref spawnerLocationObjectsComponent.FlowPrefab;

                // ref var branchSpawnPoints = ref spawnerLocationObjectsComponent.BranchSpawnPoints;
                // ref var branchPrefab = ref spawnerLocationObjectsComponent.BranchPrefab;

                ref var coinSpawnOptions = ref spawnerLocationObjectsComponent.CoinSpawnOptions;
                ref var coinPrefab = ref spawnerLocationObjectsComponent.CoinPrefab;

                ref var invulnerabilitySpawnPoints = ref spawnerLocationObjectsComponent.InvulnerabilitySpawnPoints;
                ref var invulnerabilityPrefab = ref spawnerLocationObjectsComponent.InvulnerabilityPrefab;

                ref var transformComponent = ref _spawnerLocationObjectsFilter.Get2(i);

                ref var transform = ref transformComponent.Transform;

                SpawnFlow(flowSpawnPoints, flowPrefab, transform);
                // SpawnBranch(branchSpawnPoints, branchPrefab, transform);
                SpawnCoin(coinSpawnOptions, coinPrefab, transform);
                SpawnInvulnerability(invulnerabilitySpawnPoints, invulnerabilityPrefab, transform);

                entity.Del<SpawnerLocationObjectsComponent>();
            }
        }

        private void SpawnFlow(List<Transform> flowSpawnPoints, GameObject flowPrefab, Transform transform)
        {
            var indexFlowPoint = Random.Range(0, flowSpawnPoints.Count);
            Object.Instantiate(flowPrefab, flowSpawnPoints[indexFlowPoint].position, flowSpawnPoints[indexFlowPoint].rotation, transform);
        }

        // private void SpawnBranch(List<Transform> branchSpawnPoints, GameObject branchPrefab, Transform transform)
        // {
        //     var indexBranchPoint = Random.Range(0, branchSpawnPoints.Count);
        //     Object.Instantiate(branchPrefab, branchSpawnPoints[indexBranchPoint].position, branchSpawnPoints[indexBranchPoint].rotation, transform);
        // }

        private void SpawnCoin(List<CoinSpawnOption> coinSpawnOptions, GameObject coinPrefab, Transform transform)
        {
            var indexCoinOption = Random.Range(0, coinSpawnOptions.Count);
            foreach (var coinPoint in coinSpawnOptions[indexCoinOption].SpawnPoints)
            {
                Object.Instantiate(coinPrefab, coinPoint.position, coinPoint.rotation, transform);
            }
        }

        private void SpawnInvulnerability(List<Transform> invulnerabilitySpawnPoints, GameObject invulnerabilityPrefab, Transform transform)
        {
            var probabilityInvulnerability = Random.Range(0, 2);

            if (probabilityInvulnerability == 0)
            {
                var indexInvulnerabilityPoint = Random.Range(0, invulnerabilitySpawnPoints.Count);

                Object.Instantiate(
                    invulnerabilityPrefab, 
                    invulnerabilitySpawnPoints[indexInvulnerabilityPoint].position, 
                    invulnerabilitySpawnPoints[indexInvulnerabilityPoint].rotation, 
                    transform);
            }
        }
    }
}

