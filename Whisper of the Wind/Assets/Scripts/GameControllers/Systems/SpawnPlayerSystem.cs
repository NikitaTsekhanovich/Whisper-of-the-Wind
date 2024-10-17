using DG.Tweening;
using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SpawnPlayerSystem : IEcsRunSystem
    {
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<SpawnPlayerComponent, TransformComponent> _spawnPlayerFilter = null;
        private readonly EcsFilter<RigidbodyComponent, StopClickEducationEvent> _stopClickEducationFilter = null;

        public void Run()
        {
            foreach (var i in _spawnPlayerFilter)
            {
                ref var entity = ref _spawnPlayerFilter.GetEntity(i);

                ref var spawnPlayerComponent = ref _spawnPlayerFilter.Get1(i);
                ref var startPositionPlayer = ref spawnPlayerComponent.StartPositionPlayer;

                ref var transformComponent = ref _spawnPlayerFilter.Get2(i);
                ref var transform = ref transformComponent.Transform;

                DOTween.Sequence()
                    .Append(transform.DOMove(startPositionPlayer.position, 1.5f));

                entity.Del<SpawnPlayerComponent>();
            }

            foreach (var i in _stopClickEducationFilter)
            {
                ref var entity = ref _stopClickEducationFilter.GetEntity(i);

                ref var rigidbodyComponent = ref _stopClickEducationFilter.Get1(i);
                ref var rigidbody = ref rigidbodyComponent.Rigidbody;

                StopClickEducation(ref rigidbody);

                entity.Del<StopClickEducationEvent>();
            }
        }

        private void StopClickEducation(ref Rigidbody2D rigidbody)
        {
            rigidbody.gravityScale = 10;
            _runTimeData.IsStopGame = false;
        }
    }
}

