using UnityEngine;

namespace GameControllers.Data
{
    public class GameData : MonoBehaviour
    {
        public SpriteRenderer PlayerSprite;
        public RectTransform MainCanvasRectTransform;
        [HideInInspector] public float WidthCanvas;
        [HideInInspector] public float HeightCanvas;
        [HideInInspector] public float SpawnLocationPostionX;
        [HideInInspector] public float BorderDestroyPositionX;
        public const int MultiplierLocationWidth = 16;
        public const int TimeWave = 20;
        public const int MaximumGameSpeedMultiplier = 5;
    }
}

