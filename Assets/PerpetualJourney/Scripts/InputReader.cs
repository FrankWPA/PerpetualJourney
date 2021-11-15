using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
    public class InputReader : ScriptableObject,
        GameInputAction.IRunningActions,
        GameInputAction.IDebugControlActions,
        GameInputAction.ITouchSwipeActions
    {
        [SerializeField] private float swipeRange = 300;
        [SerializeField] private float tapRange = 100;
        [SerializeField] private double swipeTime = 1;

        public event Action<int> movementEvent;
        public event Action<Vector2> swipeEvent;
        public event Action jumpEvent;
        public event Action closeEvent;
        public event Action resetEvent;

        private GameInputAction inputAction;
        private Vector2 startTouchPosition;

        private bool swipePressed = false;
        private double startTime;

        private void OnEnable()
        {
            if (inputAction == null)
            {
                inputAction = new GameInputAction();
                inputAction.Running.SetCallbacks(this);
                inputAction.DebugControl.SetCallbacks(this);
                inputAction.TouchSwipe.SetCallbacks(this);
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

        public void OnContact(InputAction.CallbackContext context)
        {
            if(context.ReadValue<float>() == 1)
            {
                StartTouch(context);
            }
            else
            {
                EndTouch(context);
            }
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
            if(!swipePressed)
            {
                return;
            }

            Vector2 currentTouchPosition = inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            double currentTime = context.time;

            if(currentTime >= (startTime + swipeTime))
            {
                SetStartTouch(currentTouchPosition, currentTime);
            }

            Vector2 distance = currentTouchPosition - startTouchPosition;

            if(Mathf.Abs(distance.x) >= swipeRange || Mathf.Abs(distance.y) >= swipeRange)
            {
                Vector2 swipeDir = DetectSwipe(distance);

                if(Mathf.Abs(swipeDir.x) == 1)
                {
                    startTouchPosition.x = currentTouchPosition.x;
                }
                else
                {
                    startTouchPosition.y = currentTouchPosition.y;
                }

                startTime = context.startTime;
            }
        }

        private void OnDisable()
        {
            inputAction.Disable();
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            Vector2 position = inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            SetStartTouch(position, context.startTime);
        }

        private void SetStartTouch(Vector2 position, double currentTime)
        {
            startTouchPosition = position;
            startTime = currentTime;
            swipePressed = true;
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            swipePressed = false;

            Vector2 endTouchPosition = inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            DetectSwipe(endTouchPosition - startTouchPosition);
        }

        private Vector2 DetectSwipe(Vector2 swipeValue)
        {
            float horizontalDist = Mathf.Abs(swipeValue.x);
            float verticalDist = Mathf.Abs(swipeValue.y);
            Vector2 swipeResult = Vector2.zero;

            if (horizontalDist <= tapRange && verticalDist <= tapRange)
            {
                return swipeResult;
            }
            
            if (Mathf.Abs(horizontalDist) > Mathf.Abs(verticalDist))
            {
                swipeResult.x = Mathf.Sign(swipeValue.x);
            }
            else
            {
                swipeResult.y = Mathf.Sign(swipeValue.y);
            }

            swipeEvent?.Invoke(swipeResult);
            return swipeResult;
        }
    }
}
