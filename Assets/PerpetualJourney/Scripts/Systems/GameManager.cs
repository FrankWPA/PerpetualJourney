using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

namespace PerpetualJourney
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private Player _player;
        [SerializeField]private GameEvents _gameEvents;
        [SerializeField]private TextMeshProUGUI _scoreText;
        [SerializeField]private GameObject _gameOverUi;
        

        public void Initialize()
        {
            PersistentLoaderSystem.instance.GameIsLoaded += ActivatePlayer;
            _gameEvents.OnObstacleCollided += OnGameOver;
            _gameEvents.OnScoreChanged += UpdateTextScore;
            _player.Initialize();
        }

        public void SceneReset()
        {
            _player.SceneReset();
            _scoreText.gameObject.SetActive(true);
            _gameOverUi.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            PersistentLoaderSystem.instance.GameIsLoaded -= ActivatePlayer;
            _gameEvents.OnObstacleCollided -= OnGameOver;
            _gameEvents.OnScoreChanged -= UpdateTextScore;
        }

        private void ActivatePlayer()
        {
            _player.gameObject.SetActive(true);
        }

        private void UpdateTextScore(int score)
        {
            _scoreText.SetText("Score: {0}", score);
        }

        private void OnGameOver()
        {
            _scoreText.gameObject.SetActive(false);
            _gameOverUi.gameObject.SetActive(true);
        }
    }
}
