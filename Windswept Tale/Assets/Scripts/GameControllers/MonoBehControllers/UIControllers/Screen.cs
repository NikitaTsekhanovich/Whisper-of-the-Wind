using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject _screen;

        public void ChangeStateScreen(bool isActive)
        {
            _screen.SetActive(isActive);
        }
    }
}

