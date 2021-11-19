using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class PersistentLoaderSystem : MonoBehaviour
    {
        public static PersistentLoaderSystem instance;
        public event Action<float> OnProgressUpdated;
        public event Action GameIsLoaded;

        public float LevelGenerationProgress {get; set;} = 0;
        public bool LevelGenerationIsDone {get; set;} = false;

        private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
        private float _sceneProgress;

        public void LoadGame()
        {
            _scenesLoading.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
            StartCoroutine(SceneLoadingProgress(2));
            StartCoroutine(GetTotalProgress());
        }

        private void Awake()
        {
            instance = this;

            _scenesLoading.Add(SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive));
            StartCoroutine(SceneLoadingProgress(1));
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
                    Debug.Log(_sceneProgress);
                    yield return null;
                }
            }

            _scenesLoading.Clear();
            yield return new WaitForSeconds(1f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(indexToActivate));
        }

        private IEnumerator GetTotalProgress()
        {
            float totalProgress = 0;
            while(GameSystem.instance == null || !LevelGenerationIsDone)
            {
                totalProgress = (_sceneProgress + LevelGenerationProgress)/2f;
                OnProgressUpdated?.Invoke(totalProgress);
            }
            
            yield return new WaitForSeconds(0.5f);
            GameIsLoaded?.Invoke();
            SceneManager.UnloadSceneAsync(1);
        }
    }
}
