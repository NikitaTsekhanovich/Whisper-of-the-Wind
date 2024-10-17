using GameControllers.Data;
using GameControllers.MonoBehControllers;
using GameControllers.MonoBehControllers.UIControllers;
using GameControllers.Systems;
using GameControllers.Systems.EventSenders;
using GameControllers.Systems.Initializers;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.Ecs
{
    public class EcsGameStartup : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private SoundsContainer _soundsContainer;
        [SerializeField] private UIContainer _uiContainer;
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            InitEcsWorld();
        }

        public void InitEcsWorld()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            var runTimeData = new RunTimeData();

            AddInjections(runTimeData);
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private void AddInjections(RunTimeData runTimeData)
        {
            _systems
                .Inject(_soundsContainer)
                .Inject(runTimeData)
                .Inject(_uiContainer)
                .Inject(_gameData);
        }

        private void AddSystems()
        {
            _systems
                .Add(new PauseGameSystem())
                .Add(new EntityInitializeSystem())
                .Add(new GameInitializeSystem())
                .Add(new SpawnPlayerSystem())
                .Add(new SpeedUpGameSystem())
                .Add(new SlowDownGameSystem())
                .Add(new InputSystem())
                .Add(new PlayerJumpSystem())
                .Add(new DestroySendEventSystem())
                .Add(new DestroySystem())
                .Add(new SpawnerGameLocationsSendEventSystem())
                .Add(new SpawnerGameLocationsSystem())
                .Add(new SpawnerLocationObjectsSystem())
                .Add(new InitializeRectTransformSystem())
                .Add(new MovableSystem())
                .Add(new TakeCoinSystem())
                .Add(new ScoreSystem())
                .Add(new InvulnerabilitySystem())
                .Add(new HealthSystem());
        }

        private void AddOneFrames()
        {
            // _systems
            //     .OneFrame<SpawnGameLocationEvent>();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}

