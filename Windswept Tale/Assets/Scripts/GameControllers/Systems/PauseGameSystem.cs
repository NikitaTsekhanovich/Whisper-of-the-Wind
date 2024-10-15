using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class PauseGameSystem : IEcsRunSystem
    {
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<PauseGameEvent> _pauseGameFilter = null;
        private readonly EcsFilter<UnpauseGameEvent> _unpauseGameFilter = null;

        public void Run()
        {
            foreach (var i in _pauseGameFilter)
            {
                ref var entity = ref _pauseGameFilter.GetEntity(i);

                Time.timeScale = 0f;
                _runTimeData.IsStopGame = true;

                entity.Del<PauseGameEvent>();
            }

            foreach (var i in _unpauseGameFilter)
            {
                ref var entity = ref _unpauseGameFilter.GetEntity(i);

                Time.timeScale = 1f;
                _runTimeData.IsStopGame = false;

                entity.Del<UnpauseGameEvent>();
            }
        }
    }
}

