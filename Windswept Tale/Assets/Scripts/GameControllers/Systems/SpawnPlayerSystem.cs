using DG.Tweening;
using GameControllers.Components;
using GameControllers.Data;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class SpawnPlayerSystem : IEcsRunSystem
    {
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<SpawnPlayerComponent, TransformComponent> _spawnPlayerFilter = null;

        public void Run()
        {
            foreach (var i in _spawnPlayerFilter)
            {
                ref var entity = ref _spawnPlayerFilter.GetEntity(i);

                ref var spawnPlayerComponent = ref _spawnPlayerFilter.Get1(i);
                ref var startPositionPlayer = ref spawnPlayerComponent.StartPositionPlayer;
                var rigidbody = spawnPlayerComponent.Rigidbody;

                ref var transformComponent = ref _spawnPlayerFilter.Get2(i);
                ref var transform = ref transformComponent.Transform;

                DOTween.Sequence()
                    .Append(transform.DOMove(startPositionPlayer.position, 1.5f))
                    .AppendCallback(() => rigidbody.gravityScale = 10)
                    .AppendCallback(() => _runTimeData.IsStopGame = false);

                entity.Del<SpawnPlayerComponent>();
            }
        }
    }
}

