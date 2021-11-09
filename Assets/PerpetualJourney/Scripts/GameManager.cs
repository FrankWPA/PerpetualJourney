using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]private PlayerSphereController playerController;
        private GameInputAction gameInputAction;

        public void OnAwake(GameInputAction inputAction)
        {
            gameInputAction = inputAction;
            inputAction.DebugControl.Enable();
            inputAction.DebugControl.ResetScene.performed += resetScene;
            inputAction.DebugControl.CloseGame.performed += closeGame;

            playerController.onAwake(inputAction);
        }

        public void onFixedUpdate() {
            playerController.onFixedUpdate();
        }

        private void OnDisable()
        {
            gameInputAction.DebugControl.Disable();
        }

        private void resetScene(InputAction.CallbackContext callback)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void closeGame(InputAction.CallbackContext callback)
        {
            Application.Quit();
        }
    }
}
