using GameControllers.Components.Events;
using GameControllers.Data;
using GameControllers.MonoBehControllers;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class SlowDownGameSystem : IEcsRunSystem
    {
        private readonly SoundsContainer _soundsContainer;
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<SlowingDownGameEvent> _slowingDownEventFilter = null;

        public void Run()
        {
            foreach (var i in _slowingDownEventFilter)
            {
                ref var entity = ref _slowingDownEventFilter.GetEntity(i);
                
                _runTimeData.GameSpeedMultiplier--;
                _soundsContainer.SpeedUpSound.Stop();

                entity.Del<SlowingDownGameEvent>();
            }
        }
    }
}

