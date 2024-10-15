using GameControllers.Components.Events;
using GameControllers.Data;
using GameControllers.MonoBehControllers;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class SpeedUpGameSystem : IEcsRunSystem
    {
        private readonly SoundsContainer _soundsContainer;
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<SpeedingUpGameEvent> _speedingUpEventFilter = null;

        public void Run()
        {
            foreach (var i in _speedingUpEventFilter)
            {
                ref var entity = ref _speedingUpEventFilter.GetEntity(i);
                
                _runTimeData.GameSpeedMultiplier++;
                _soundsContainer.SpeedUpSound.Play();

                entity.Del<SpeedingUpGameEvent>();
            }
        }
    }
}

