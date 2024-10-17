using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, PhysicComponent, JumpEvent> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);

                ref var movableComponent = ref _playerFilter.Get1(i);
                ref var speed = ref movableComponent.Speed;

                ref var physicComponent = ref _playerFilter.Get2(i);
                ref var rigidbody = ref physicComponent.Rigidbody;

                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(Vector2.up * speed);

                entity.Del<JumpEvent>();
            }
        }
    }
}

