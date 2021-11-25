using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Player : MonoBehaviour
    {
        [SerializeField]private MovementController _movementController;
        [SerializeField]private TransformOffset _cameraFocus;
        [SerializeField]private InputReader _inputReader;
        [SerializeField]private GameEvents _gameEvents;
        
        private int _score;

        public void Initialize()
        {
            _inputReader.Initialize();
            _movementController.Initialize(_inputReader, _gameEvents);
            _cameraFocus.Initialize(_movementController.transform);

            _gameEvents.OnObstacleCollided += OnObstacleCollided;
            _gameEvents.OnCollectableCollided += OnCollecting;
        }

        public void SceneReset()
        {
            _score = 0;
            _gameEvents.IncreasePlayerScore(_score);
            _movementController.transform.position = transform.position;
            _movementController.SceneReset();
        }

        private void OnDisable()
        {
            _inputReader.DisableReader();
            _gameEvents.OnObstacleCollided -= OnObstacleCollided;
            _gameEvents.OnCollectableCollided -= OnCollecting;
        }

        private void OnObstacleCollided()
        {
            _movementController.gameObject.SetActive(false);
            
            SoundPlayer.Instance.PlayAudio(SoundPlayer.AudioEnum.Horn);
            SoundPlayer.Instance.PlayAudio(SoundPlayer.AudioEnum.Shatter);
        }

        private void OnCollecting()
        {
            _score += 1;
            
            _gameEvents.IncreasePlayerScore(_score);
            SoundPlayer.Instance.PlayAudio(SoundPlayer.AudioEnum.Swallow);
        }
    }
}
