using TMPro;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class GameSpeedMultiplierText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameSpeedMultiplierText;

        public void IncreaseGameSpeedMultiplierText(float gameSpeedMultiplier)
        {
            _gameSpeedMultiplierText.text = $"Speed: {gameSpeedMultiplier}";
        }
    }
}

