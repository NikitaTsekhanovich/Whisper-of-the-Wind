using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct SpawnPlayerComponent
    {
        public Transform StartPositionPlayer;
        public Rigidbody2D Rigidbody;
    }
}

