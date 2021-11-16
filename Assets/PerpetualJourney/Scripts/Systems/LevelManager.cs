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

        private LTDescr _playerPositionChecker;
        private Vector3 _playerPosition = new Vector3();
        private Vector3 _lastPosition;
        
        private const float GenerationDistance = 100f;
        private const float CheckFrequency = 1f;

        public void Initialize()
        {
            _lastPosition = _levelGenPosition.position;
            
            _playerPositionChecker = LeanTween.delayedCall(CheckFrequency, () => 
            {
                UpdatePlayerPosition(_gameEvents.RequestPlayerPosition());
            }).setRepeat(-1);
        }

        private void OnDisable()
        {
            LeanTween.cancel(_playerPositionChecker.id);
        }

        private void UpdatePlayerPosition(Vector3? pos)
        {
            if (pos.HasValue)
            {
                _playerPosition = pos.Value;
            }
        }

        private void Update()
        {
            if (Vector3.Distance(_playerPosition, _lastPosition) < GenerationDistance)
            {
                InstantiateLevelPart();
            }   
        }

        private void InstantiateLevelPart()
        {
            LevelPart randomLevel = _levelList[Random.Range(0, _levelList.Count)];
            LevelPart instantiatedLevel = instatiateLevelPart(randomLevel, _lastPosition);

            _lastPosition = instantiatedLevel.LevelEndPosition;
        }

        private LevelPart instatiateLevelPart(LevelPart levelPart, Vector3 instancePosition)
        {
            LevelPart part = Instantiate(levelPart, instancePosition, Quaternion.identity);
            part.Initialize();
            
            return part;
        }
    }
}
