using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private PlayerController playerController;
        [SerializeField]private InputReader _inputReader = default;

        public void Initialize()
        {
            _inputReader.resetEvent += onResetEvent;
            _inputReader.closeEvent += onCloseEvent;
            playerController.Initialize();
        }

        private void OnDisable()
        {
            _inputReader.resetEvent -= onResetEvent;
            _inputReader.closeEvent -= onCloseEvent;
        }

        private void onResetEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void onCloseEvent()
        {
            Application.Quit();
        }
    }
}
