using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class LocationsCompletedText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _locationsCompleted;

        public void UpdateLocationsCompleted(int locationsCompleted)
        {
            _locationsCompleted.text = $"Locations completed: {locationsCompleted}!";

            DOTween.Sequence()
                .Append(_locationsCompleted.transform.DOScale(new Vector3(1f, 1f, 1f), 1f))
                .AppendInterval(1f)
                .Append(_locationsCompleted.transform.DOScale(Vector3.zero, 1f));
        }
    }
}

