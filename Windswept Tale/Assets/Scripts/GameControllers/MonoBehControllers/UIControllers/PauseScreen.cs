using System.Collections;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using PlayerData;
using TMPro;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class PauseScreen : Screen
    {
        [SerializeField] private TMP_Text _bestScoreText;
        [SerializeField] private TMP_Text _coinsText;

        public void PauseGame()
        {
            _bestScoreText.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.BestScoreTextKey)}";
            _coinsText.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey)}";

            WorldHandler.GetWorld().NewEntity().Get<PauseGameEvent>();
            ChangeStateScreen(true);
        }

        public void ContinueGame()
        {
            Time.timeScale = 1f;
            ChangeStateScreen(false);
            StartCoroutine(WaitDelay());
        }

        private IEnumerator WaitDelay()
        {
            yield return new WaitForSeconds(0.1f);
            WorldHandler.GetWorld().NewEntity().Get<UnpauseGameEvent>();
        }
    }
}

