using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems.EventSenders
{
    public class DestroySendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroySendEvent> _destroySendEventFilter = null;
        private readonly EcsFilter<GameLocationTag, TransformComponent> _spawnerComponentFilter = null;

        public void Run()
        {
            foreach (var i in _destroySendEventFilter)
            {
                ref var entityEvent = ref _destroySendEventFilter.GetEntity(i);

                foreach (var j in _spawnerComponentFilter)
                {
                    ref var entitySpawner = ref _spawnerComponentFilter.GetEntity(j);
                    entitySpawner.Get<DestroyEvent>();
                }

                entityEvent.Del<DestroySendEvent>();
            }
        }
    }
}

