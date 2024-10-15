using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<TransformComponent, DestroyEvent> _destroyEventFilter = null;

        public void Run()
        {
            foreach (var i in _destroyEventFilter)
            {
                ref var entity = ref _destroyEventFilter.GetEntity(i);

                ref var transformComponent = ref _destroyEventFilter.Get1(i);
                ref var transform = ref transformComponent.Transform;

                Object.Destroy(transform.gameObject);

                _world.NewEntity().Get<SpawnGameLocationsSendEvent>();

                entity.Destroy();
            }
        }
    }
}

