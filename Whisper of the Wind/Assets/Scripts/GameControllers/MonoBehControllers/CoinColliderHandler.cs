using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.MonoBehControllers
{
    public class CoinColliderHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            WorldHandler.GetWorld().NewEntity().Get<TakeCoinEvent>();
            Destroy(gameObject);
        }
    }
}

