using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class PersistentLoaderSystem : MonoBehaviour
    {
        public static PersistentLoaderSystem Instance;
        public event Action<float> OnProgressUpdated;
        public event Action GameIsLoaded;

        public float LevelGenerationProgress {get; set;} = 0;
        public bool LevelGenerationIsDone {get; set;} = false;

        private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
        private float _sceneProgress;
        
        public void InitializeSystem()
        {
            Instance = this;
            LoadMenu();
        }

        public void LoadMenu()
        {
            _scenesLoading.Add(SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive));

            UnloadCurrentScene(0);
            StartCoroutine(SceneLoadingProgress(1));
        }
        
        public void LoadGame()
        {
            _scenesLoading.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
            StartCoroutine(SceneLoadingProgress(2));
            StartCoroutine(UpdateTotalProgressAndUnload(1));
        }

        private bool UnloadCurrentScene(int indexToIgnore)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if(currentSceneIndex != indexToIgnore)
            {
                SceneManager.UnloadSceneAsync(currentSceneIndex);
                return true;
            }
            return false;
        }

        private void Awake()
        {
            InitializeSystem();
        }

        private IEnumerator SceneLoadingProgress(int indexToActivate)
        {
            for(int i = 0; i < _scenesLoading.Count; i++)
            {
                while(!_scenesLoading[i].isDone)
                {
                    _sceneProgress = 0;
                    foreach(AsyncOperation operation in _scenesLoading)
                    {
                        _sceneProgress += operation.progress;
                    }

                    _sceneProgress = (_sceneProgress/_scenesLoading.Count);
                    yield return null;
                }
            }

            _sceneProgress = 1;
            _scenesLoading.Clear();
            yield return new WaitForSeconds(0.5f);

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexToActivate));
        }

        private IEnumerator UpdateTotalProgressAndUnload(int indexToUnload)
        {
            float totalProgress = 0;
            while(GameSystem.Instance == null || !LevelGenerationIsDone)
            {
                totalProgress = (_sceneProgress + LevelGenerationProgress)/2f;
                OnProgressUpdated?.Invoke(totalProgress);
                yield return null;
            }

            GameIsLoaded?.Invoke();
            SceneManager.UnloadSceneAsync(indexToUnload);
        }
    }
}
