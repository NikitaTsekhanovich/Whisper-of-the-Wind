using System;
using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using GameControllers.Data;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class MovableSystem : IEcsRunSystem
    {
        private readonly GameData _gameData;
        private readonly RunTimeData _runTimeData;
        private readonly EcsWorld _world;
        private readonly EcsFilter<GameLocationTag, MovableComponent, TransformComponent> _movableComponentFilter = null;

        public static Action OnEndBranchAnimations;

        public void Run()
        {
            foreach (var i in _movableComponentFilter)
            {
                if (_runTimeData.IsStopGame) return;

                ref var entity = ref _movableComponentFilter.GetEntity(i);
                
                ref var movableComponent = ref _movableComponentFilter.Get2(i);
                ref var speed = ref movableComponent.Speed;

                ref var transformComponent = ref _movableComponentFilter.Get3(i);
                ref var transform = ref transformComponent.Transform;

                transform.position += new Vector3(speed * Time.deltaTime * _runTimeData.GameSpeedMultiplier, 0f, 0f);

                if (transform.localPosition.x <= _gameData.BorderDestroyPositionX)
                {
                    OnEndBranchAnimations.Invoke();
                    _world.NewEntity().Get<DestroySendEvent>();
                    _runTimeData.AmountWaves++;

                    if (_runTimeData.GameSpeedMultiplier < 3)
                    {
                        _runTimeData.GameSpeedMultiplier += 0.5f;
                    }
                }
            }
        }
    }
}

