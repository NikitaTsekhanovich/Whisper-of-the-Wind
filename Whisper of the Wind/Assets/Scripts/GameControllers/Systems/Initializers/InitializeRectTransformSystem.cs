using GameControllers.Components;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems.Initializers
{
    public class InitializeRectTransformSystem : IEcsRunSystem
    {
        private readonly GameData _gameData;
        private readonly EcsFilter<RectTransformComponent> _rectTransformFilter = null; 

        public void Run()
        {
            foreach (var i in _rectTransformFilter)
            {
                ref var entity = ref _rectTransformFilter.GetEntity(i);

                ref var RectTransformComponent = ref _rectTransformFilter.Get1(i);
                ref var rectTransform = ref RectTransformComponent.RectTransform;

                rectTransform.sizeDelta = new Vector2(_gameData.WidthCanvas * GameData.MultiplierLocationWidth, _gameData.HeightCanvas);

                entity.Del<RectTransformComponent>();
            }
        }
    }
}

