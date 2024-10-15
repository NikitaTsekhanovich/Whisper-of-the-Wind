using GameControllers.Components;
using GameControllers.Data;
using GameControllers.MonoBehControllers.UIControllers;
using Leopotam.Ecs;
using PlayerData;
using UnityEngine;

namespace GameControllers.Systems
{
    public class ScoreSystem : IEcsRunSystem
    {
        private readonly UIContainer _uiContainer;
        private readonly RunTimeData _runTimeData;
        private readonly EcsFilter<ScoreComponent> _scoreFilter = null;

        public void Run()
        {
            foreach (var i in _scoreFilter)
            {
                ref var scoreComponent = ref _scoreFilter.Get1(i);
                ref var currentScore = ref scoreComponent.CurrentScore;

                if (!_runTimeData.IsStopGame)
                {
                    currentScore += (int)_runTimeData.GameSpeedMultiplier;
                    _uiContainer.ScoreText.IncreaseScore(currentScore);
                }
                else if (_runTimeData.IsGameOver)
                {
                    ref var entity = ref _scoreFilter.GetEntity(i);

                    var bestScore = PlayerPrefs.GetInt(PlayerDataKeys.BestScoreTextKey);

                    if (bestScore < currentScore)
                    {
                        bestScore = currentScore;
                        PlayerPrefs.SetInt(PlayerDataKeys.BestScoreTextKey, currentScore);
                    }

                    _uiContainer.LoseScreen.ShowLoseScreen(bestScore, currentScore);
                    
                    entity.Del<ScoreComponent>();
                }                
            }
        }
    }
}

