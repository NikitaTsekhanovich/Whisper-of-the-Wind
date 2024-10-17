using GameControllers.Components.Events;
using GameControllers.MonoBehControllers;
using Leopotam.Ecs;
using PlayerData;
using UnityEngine;

namespace GameControllers.Systems
{
    public class TakeCoinSystem : IEcsRunSystem
    {
        private readonly SoundsContainer _soundsContainer;
        private readonly EcsFilter<TakeCoinEvent> _takeCoinFilter= null;

        public void Run()
        {
            foreach (var i in _takeCoinFilter)
            {
                ref var entity = ref _takeCoinFilter.GetEntity(i);

                var currentCoins = PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey);
                PlayerPrefs.SetInt(PlayerDataKeys.CoinsKey, currentCoins + 1);
                _soundsContainer.TakeCoinSound.Play();

                entity.Del<TakeCoinEvent>();
            }
        }
    }
}

