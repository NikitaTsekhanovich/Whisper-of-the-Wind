using UnityEngine;

namespace MainMenuControllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsBlock;
        private bool _isSettingsBlockActive;

        public void StartGame()
        {
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void ChangeStateSettingsBlock()
        {
            _isSettingsBlockActive = !_isSettingsBlockActive;
            _settingsBlock.SetActive(_isSettingsBlockActive);
        }
    }
}

