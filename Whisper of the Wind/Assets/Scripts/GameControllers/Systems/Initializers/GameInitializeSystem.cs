using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using MainMenuControllers.Store;
using UnityEngine;

namespace GameControllers.Systems.Initializers
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        private readonly RunTimeData _runTimeData;
        private readonly GameData _gameData;
        private readonly EcsWorld _world;
        
        public void Init()
        {
            _runTimeData.GameSpeedMultiplier = 1f;
            _world.NewEntity().Get<SpawnGameLocationsSendEvent>();
            InitGameData();
            InitPlayerSkins();
            _runTimeData.IsStopGame = true;
        }

        private void InitGameData()
        {
            _gameData.WidthCanvas = _gameData.MainCanvasRectTransform.rect.width;
            _gameData.HeightCanvas = _gameData.MainCanvasRectTransform.rect.height;
            _gameData.SpawnLocationPostionX = _gameData.WidthCanvas + _gameData.WidthCanvas * (GameData.MultiplierLocationWidth / 2);
            _gameData.BorderDestroyPositionX = 0 - (_gameData.MainCanvasRectTransform.rect.width + _gameData.WidthCanvas * (GameData.MultiplierLocationWidth / 2));
        }

        private void InitPlayerSkins()
        {
            _gameData.PlayerSprite.sprite = SkinsDataContainer.SkinsData[PlayerPrefs.GetInt(StoreDataKeys.IndexChosenItemKey)].Icon;
        }
    }
}
