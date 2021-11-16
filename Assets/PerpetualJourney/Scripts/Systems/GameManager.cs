using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private Player _player;
        [SerializeField]private InputReader _inputReader;

        public void Initialize()
        {
            _inputReader.OnResetEvent += OnResetEvent;
            _inputReader.OnCloseEvent += OnCloseEvent;
            _player.Initialize();
        }

        private void OnDisable()
        {
            _inputReader.OnResetEvent -= OnResetEvent;
            _inputReader.OnCloseEvent -= OnCloseEvent;
        }

        private void OnResetEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnCloseEvent()
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    }
}
