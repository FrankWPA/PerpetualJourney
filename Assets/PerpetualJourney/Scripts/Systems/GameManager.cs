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
        [SerializeField]private InputReader _inputReader;
        [SerializeField]private GameEvents _gameEvents;
        [SerializeField]private TextMeshProUGUI _scoreText;

        public void Initialize()
        {
            _inputReader.Initialize();
            _inputReader.OnResetEvent += OnResetEvent;
            _inputReader.OnCloseEvent += OnCloseEvent;
            _gameEvents.OnScoreChanged += UpdateTextScore;
            _player.Initialize();
        }

        private void OnDisable()
        {
            _inputReader.OnResetEvent -= OnResetEvent;
            _inputReader.OnCloseEvent -= OnCloseEvent;
            _gameEvents.OnScoreChanged -= UpdateTextScore;
            _inputReader.DisableReader();
        }

        private void UpdateTextScore(int score)
        {
            _scoreText.SetText("Score: {0}", score);
        }

        private void OnResetEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnCloseEvent()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
