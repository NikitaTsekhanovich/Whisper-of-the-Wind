using GameControllers.Components.Events;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class DamageColliderHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<EntityReference>(out var entityReference))
                entityReference.Entity.Get<DamageEvent>();
        }
    }
}

