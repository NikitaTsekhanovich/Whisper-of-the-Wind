using System;
using MainMenuControllers.Store;
using PlayerData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneControllers
{
    public class SceneDataLoader : MonoBehaviour
    {
        public static Action OnLoadStoreSkinsData;
        public static Action OnShowFirstEducation;
        public static SceneDataLoader Instance;

        private TypeLaunch _isFirstLaunch;

        private void Start() 
        {             
            if (Instance == null) 
                Instance = this;  
            else 
                Destroy(this);   
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "MainMenu")
            {
                CheckFirstLaunch();
                SkinsDataContainer.LoadSkinsData();
                OnLoadStoreSkinsData.Invoke();
            }
            else if (scene.name == "Game")
            {
                if (_isFirstLaunch == TypeLaunch.IsFirst)
                    OnShowFirstEducation.Invoke();

                _isFirstLaunch = TypeLaunch.IsNotFirst;
            }
        }

        private void CheckFirstLaunch()
        {
            _isFirstLaunch = (TypeLaunch)PlayerPrefs.GetInt(PlayerDataKeys.IsFirstLaunchGameKey);

            if (_isFirstLaunch == (int)TypeLaunch.IsFirst)
            {
                PlayerPrefs.SetInt(PlayerDataKeys.IsFirstLaunchGameKey, (int)TypeLaunch.IsNotFirst);
                PlayerPrefs.SetInt($"{StoreDataKeys.StateItemKey}{0}", (int)TypeItemStore.Selected);
                PlayerPrefs.SetInt(StoreDataKeys.IndexChosenItemKey, 0);
            }
        }
    }
}

