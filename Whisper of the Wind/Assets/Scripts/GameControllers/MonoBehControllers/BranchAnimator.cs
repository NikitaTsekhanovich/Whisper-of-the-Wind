using DG.Tweening;
using GameControllers.Systems;
using UnityEngine;

namespace GameControllers.MonoBehControllers
{
    public class BranchAnimator : MonoBehaviour
    {
        [SerializeField] private TypeBranch _typeBranch;
        private Sequence _animationBigBranch = null;
        private Sequence _animationSmallBranch = null;

        private void OnEnable()
        {
            MovableSystem.OnEndBranchAnimations += EndBranchAnimations;
        }

        private void OnDisable()
        {
            MovableSystem.OnEndBranchAnimations -= EndBranchAnimations;
        }

        private void Start()
        {
            if (_typeBranch == TypeBranch.Big)
            {
                StartAnimationBigBranch();
            }
            else if (_typeBranch == TypeBranch.Small)
            {
                StartAnimationSmallBranch();
            }
        }

        private void StartAnimationBigBranch()
        {
            _animationBigBranch = DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(0.95f, 0.8f, 1f), 1f))
                .Append(transform.DOScale(new Vector3(1f, 1f, 1f), 1f))
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void StartAnimationSmallBranch()
        {
            _animationSmallBranch = DOTween.Sequence()
                .Append(transform
                    .DOLocalRotate(new Vector3(0, 0, 360), 3f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Yoyo));
        }

        private void EndBranchAnimations()
        {
            _animationBigBranch?.Kill();
            _animationSmallBranch?.Kill();
        }
    }
}

