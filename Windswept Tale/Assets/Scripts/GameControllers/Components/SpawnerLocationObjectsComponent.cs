using System.Collections.Generic;
using UnityEngine;
using System;
using GameControllers.Components.Auxiliary;

namespace GameControllers.Components
{
    [Serializable]
    public struct SpawnerLocationObjectsComponent
    {
        public List<Transform> FlowSpawnPoints;
        // public List<Transform> BranchSpawnPoints;
        public List<CoinSpawnOption> CoinSpawnOptions;
        public List<Transform> InvulnerabilitySpawnPoints;
        public GameObject FlowPrefab;
        // public GameObject BranchPrefab;
        public GameObject CoinPrefab;
        public GameObject InvulnerabilityPrefab;
    }
}

