using PlayerData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class LoseScreen : Screen
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _bestScoreText;
        [SerializeField] private Button _pauseButton;

        public void ShowLoseScreen(int bestScore, int currentScore)
        {
            _pauseButton.interactable = false;

            _scoreText.text = $"{currentScore}";
            _coinsText.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.CoinsKey)}";
            _bestScoreText.text = $"{bestScore}";

            ChangeStateScreen(true);
        }

        public void RestartGame()
        {
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void BackToMenu()
        {
            LoadingScreenController.Instance.ChangeScene("MainMenu");
        }
    }
}

