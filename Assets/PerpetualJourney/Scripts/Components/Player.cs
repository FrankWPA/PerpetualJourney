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
        public int Score {get; private set;}

        public void Initialize()
        {
            _inputReader.Initialize();
            _laneController.Initialize(_inputReader, _gameEvents);
            _cameraFocus.Initialize(_laneController.transform);

            _gameEvents.OnObstacleCollided += OnObstacleCollided;
            _gameEvents.OnCollectableCollided += OnCollecting;
        }

        public void SceneReset()
        {
            Score = 0;
            _gameEvents.IncreasePlayerScore(Score);
            _laneController.transform.position = transform.position;
            _laneController.SceneReset();
        }

        private void OnDisable()
        {
            _inputReader.DisableReader();
            _gameEvents.OnObstacleCollided -= OnObstacleCollided;
        }

        private void OnObstacleCollided()
        {
            _laneController.gameObject.SetActive(false);
            
            SoundPlayer.instance.PlayAudio(SoundPlayer.AudioEnum.Horn);
            SoundPlayer.instance.PlayAudio(SoundPlayer.AudioEnum.Shatter);
        }

        private void OnCollecting()
        {
            Score += 1;
            
            _gameEvents.IncreasePlayerScore(Score);
            SoundPlayer.instance.PlayAudio(SoundPlayer.AudioEnum.Swallow);
        }
    }
}
