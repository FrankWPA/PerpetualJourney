using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Player : MonoBehaviour
    {
        [SerializeField]private LaneController _laneController;
        [SerializeField]private TransformOffset _cameraFocus;
        [SerializeField]private InputReader _inputReader;
        [SerializeField]private GameEvents _gameEvents;

        public bool IsAlive {get; private set;} = true;
        public float Score {get; private set;}

        public void Initialize()
        {
            _laneController.Initialize(_inputReader, _gameEvents);
            _cameraFocus.Initialize(_laneController.transform);

            _gameEvents.OnObstacleCollided += OnObstacleCollided;
            _gameEvents.OnCollectableCollided += OnCollecting;
        }

        private void OnDisable()
        {
            _gameEvents.OnObstacleCollided -= OnObstacleCollided;
        }

        private void OnObstacleCollided()
        {
            IsAlive = false;
            _laneController.gameObject.SetActive(false);
        }

        private void OnCollecting()
        {
            Score += 1;
            _gameEvents.IncreasePlayerScore(Score);
        }
    }
}
