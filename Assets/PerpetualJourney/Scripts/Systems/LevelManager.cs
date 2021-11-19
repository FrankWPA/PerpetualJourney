using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform _levelGenPosition;
        [SerializeField] private List<LevelPart> _levelList;
        [SerializeField] private GameEvents _gameEvents;
        [SerializeField] private ObjectPool _objectPool;

        private Vector3 _playerPosition = new Vector3();
        private Vector3 _lastLevelPosition;
        
        private const float GenerationDistance = 120f;
        private const float CheckFrequency = 5f;

        private float progress;
        private bool isDone;

        public void Initialize()
        {
            _lastLevelPosition = _levelGenPosition.position;

            StartCoroutine(GenerateLevelAsync(300));
            StartCoroutine(PlayerPositionCheckerAsync());
        }

        private void InstantiateLevelPart()
        {
            LevelPart randomLevel = _levelList[Random.Range(0, _levelList.Count)];
            LevelPart instantiatedLevel = instantiateLevelPart(randomLevel, _lastLevelPosition);

            _lastLevelPosition = instantiatedLevel.LevelEndPosition;
        }

        private LevelPart instantiateLevelPart(LevelPart levelPart, Vector3 instancePosition)
        {
            LevelPart part = _objectPool.GetObject(levelPart);
            part.transform.SetParent(transform);
            part.transform.position = instancePosition;
            part.Initialize();
            
            return part;
        }
        
        private IEnumerator PlayerPositionCheckerAsync()
        {
            while(true){
                yield return new WaitForSeconds(CheckFrequency);
                _gameEvents.RequestPlayerPosition(ref _playerPosition);

                StartCoroutine(GenerateLevelAsync(GenerationDistance));
            }
        }

        private IEnumerator GenerateLevelAsync(float genDistance)
        {
            while (Vector3.Distance(_playerPosition, _lastLevelPosition) < genDistance)
            {
                InstantiateLevelPart();
                yield return null;

                if(!isDone)
                {
                    UpdateSceneLoadProgress(Vector3.Distance(_playerPosition, _lastLevelPosition)/genDistance);
                }
            }

            if (!isDone)
            {
                yield return new WaitForSeconds(0.5f);
                UpdateSceneLoadProgress(1);
                isDone = true;
                PersistentLoaderSystem.instance.LevelGenerationIsDone = true;
            }
        }

        private void UpdateSceneLoadProgress(float value)
        {
            progress = value;
            PersistentLoaderSystem.instance.LevelGenerationProgress = progress;
        }
    }
}
