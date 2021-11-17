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
        
        private const float GenerationDistance = 100f;
        private const float CheckFrequency = 1f;

        public void Initialize()
        {
            _lastLevelPosition = _levelGenPosition.position;
            StartCoroutine(PlayerPositionCheckerAsync());
        }

        private void Update()
        {
            if (Vector3.Distance(_playerPosition, _lastLevelPosition) < GenerationDistance)
            {
                InstantiateLevelPart();
            }   
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
            part.transform.position = instancePosition;
            part.Initialize();
            
            return part;
        }
        
        private IEnumerator PlayerPositionCheckerAsync()
        {
            while(true){
                yield return new WaitForSeconds(CheckFrequency);
                _gameEvents.RequestPlayerPosition(ref _playerPosition);
            }
        }
    }
}
