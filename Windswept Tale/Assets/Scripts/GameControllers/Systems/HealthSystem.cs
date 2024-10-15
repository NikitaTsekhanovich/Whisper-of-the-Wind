using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using GameControllers.Data;
using GameControllers.MonoBehControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class HealthSystem : IEcsRunSystem
    {
        private readonly SoundsContainer _soundsContainer;
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<PlayerTag, TransformComponent, DamageEvent> _playerHealthFilter = null;

        public void Run()
        {
            foreach (var i in _playerHealthFilter)
            {
                ref var entity = ref _playerHealthFilter.GetEntity(i);

                ref var transformComponent = ref _playerHealthFilter.Get2(i);
                ref var transform = ref transformComponent.Transform;

                _runTimeData.IsGameOver = true;
                _runTimeData.IsStopGame = true;
                _soundsContainer.CollisionBranchSound.Play();
                _soundsContainer.GameOverSound.Play();
                                
                Object.Destroy(transform.gameObject);
                entity.Destroy();
            }
        }
    }
}

