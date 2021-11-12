using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
    public class InputReader : ScriptableObject, GameInputAction.IRunningActions, GameInputAction.IDebugControlActions
    {
        public event Action<int> movementEvent;
        public event Action jumpEvent;
        public event Action closeEvent;
        public event Action resetEvent;


        private GameInputAction inputAction;

        private void OnEnable()
        {
            if (inputAction == null)
            {
                inputAction = new GameInputAction();
                inputAction.Running.SetCallbacks(this);
                inputAction.DebugControl.SetCallbacks(this);
                
            }
            inputAction.Enable();
        }

        public void OnResetScene(InputAction.CallbackContext context)
        {
            resetEvent?.Invoke();
        }

        public void OnCloseGame(InputAction.CallbackContext context)
        {
            closeEvent?.Invoke();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if(context.performed){
                movementEvent?.Invoke((int)context.ReadValue<float>());
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            jumpEvent?.Invoke();
        }

        private void OnDisable() {
            inputAction.Disable();
        }
    }
}
