using DG.Tweening;
using GameControllers.Components.Events;
using GameControllers.Ecs;
using Leopotam.Ecs;
using SceneControllers;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonoBehControllers
{
    public class EducationController : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _mainEducationBlock;
        [SerializeField] private EntityReference _playerEntityReference;
        private bool _isStart;

        private void OnEnable()
        {
            SceneDataLoader.OnShowFirstEducation += ShowMainEducation;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnShowFirstEducation -= ShowMainEducation;
        }

        public void CloseEducation()
        {
            if (_isStart) return;

            _isStart = true;

            DOTween.Sequence()
                .Append(transform.DOScale(Vector3.zero, 0.5f))
                .AppendCallback(() => _playerEntityReference.Entity.Get<StopClickEducationEvent>())
                .AppendCallback(() => _pauseButton.interactable = true)
                .AppendCallback(() => Destroy(gameObject));
        }

        private void ShowMainEducation()
        {
            _mainEducationBlock.SetActive(true);
        }
    }
}

