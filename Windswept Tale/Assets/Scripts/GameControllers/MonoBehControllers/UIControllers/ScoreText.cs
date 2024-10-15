using TMPro;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public void IncreaseScore(int currentScore)
        {
            _scoreText.text = $"Score: {currentScore}";
        }
    }
}

