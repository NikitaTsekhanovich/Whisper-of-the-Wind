using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct ScoreComponent
    {
        [HideInInspector] public int CurrentScore;
    }
}

