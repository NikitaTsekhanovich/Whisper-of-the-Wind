using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<PlayerTag, MovableComponent> _playerFilter = null;

        public void Run()
        {
            if (Input.GetMouseButtonUp(0) && !_runTimeData.IsStopGame)
            {
                foreach (var i in _playerFilter)
                {
                    ref var entity = ref _playerFilter.GetEntity(i);
                    entity.Get<JumpEvent>();
                }
            }
        }
    }
}

